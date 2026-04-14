using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlowerLocator : MonoBehaviour
{
    [SerializeField] private float indicatorDistanceFromPlayer = 3f;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject hive;

    public GameObject[] flowers;
    private GameObject player;

    private void Start()
    {
        player = FindAnyObjectByType<BeeMovement>().gameObject;
        StartCoroutine(IndicatorRoutine());
    }

    private IEnumerator IndicatorRoutine()
    {
        while (true)
        {
            Vector3 directionToFlower = (GetNearestFlower().transform.position - player.transform.position).normalized;
            indicator.transform.position = directionToFlower * indicatorDistanceFromPlayer + player.transform.position;
            indicator.transform.rotation = Quaternion.LookRotation(Vector3.forward, directionToFlower);
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
