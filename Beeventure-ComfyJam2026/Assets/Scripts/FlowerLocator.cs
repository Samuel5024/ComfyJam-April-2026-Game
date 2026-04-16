using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlowerLocator : MonoBehaviour
{
    [SerializeField] private float indicatorDistanceFromPlayer = 3f;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject hive;
    [SerializeField] private float smoothing = 0.01f;

    private Vector3 DesiredLocation;
    private Quaternion DesiredRotation;

    public GameObject[] flowers;
    private GameObject player;

    private void Start()
    {
        if (ConstantData.hatType != HatType.Detection)
        {
            indicator.SetActive(false);
            return;
        }

        indicator.SetActive(true);
        player = FindAnyObjectByType<BeeMovement>().gameObject;
        StartCoroutine(IndicatorRoutine());
        indicator.transform.position = DesiredLocation;
    }

    private void Update()
    {
       indicator.transform.position = Vector3.Lerp(indicator.transform.position, DesiredLocation, smoothing);
        indicator.transform.rotation = Quaternion.Lerp(indicator.transform.rotation, DesiredRotation, smoothing);
    }

    private IEnumerator IndicatorRoutine()
    {
        while (true)
        {
            Vector3 directionToFlower = (GetNearestFlower().transform.position - player.transform.position).normalized;
            DesiredLocation = directionToFlower * indicatorDistanceFromPlayer + player.transform.position;
            DesiredRotation = Quaternion.LookRotation(Vector3.forward, directionToFlower);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SetFlowers(GameObject[] flowers)
    {
        this.flowers = flowers;
    }

    private GameObject GetNearestFlower()
    {
        float nearest = Mathf.Infinity;
        GameObject nearestGO = null;
        foreach (GameObject go in flowers)
        {
            if(go == null) continue;
            if ( nearest > Vector3.Distance(go.transform.position, player.transform.position))
            {
                nearestGO = go;
                nearest = Vector3.Distance(go.transform.position, player.transform.position);
            }
        }

        if (nearestGO == null)
        {
            return hive;
        }
        return nearestGO;
    }
}
