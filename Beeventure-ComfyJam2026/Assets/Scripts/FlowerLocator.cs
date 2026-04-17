using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlowerLocator : MonoBehaviour
{
    [SerializeField] private float indicatorDistanceFromPlayer = 3f;
    [SerializeField] private IndicatorMovement indicator;
    [SerializeField] private GameObject hive;
    [SerializeField] private float smoothing = 0.01f;
    [SerializeField] private float ShowDistance = 0.5f;
    [SerializeField] private float refreshRate = 0.05f;

    public GameObject[] flowers;
    private GameObject player;
    private IndicatorMovement[] indicators;

    private void Start()
    {
        indicator.SetSmoothing(smoothing);
        player = FindAnyObjectByType<BeeMovement>().gameObject;

        if (ConstantData.hatType == HatType.Detection && ConstantData.hatTeir > 1)
        {
            indicators = new IndicatorMovement[flowers.Length];
            
            for(int i = 0; i < indicators.Length; i++)
            {
                indicators[i] = Instantiate(indicator);
            }
            StartCoroutine(T2IndicatorRoutine());
            return;
        }

        indicator.gameObject.SetActive(true);
        StartCoroutine(IndicatorRoutine());
    }

    private IEnumerator IndicatorRoutine()
    {
        while (true)
        {
            Vector3 directionToFlower = (GetNearestFlower().transform.position - player.transform.position).normalized;
            indicator.SetDesiredLocation(directionToFlower * indicatorDistanceFromPlayer + player.transform.position);
            indicator.SetDesiredRotation(Quaternion.LookRotation(Vector3.forward, directionToFlower));
            yield return new WaitForSeconds(refreshRate);

            if(ConstantData.hatType == HatType.Detection)
            {
                continue;
            }

            if(Vector3.Distance(GetNearestFlower().transform.position, player.transform.position) < ShowDistance)
            {
                indicator.gameObject.SetActive(true);
                continue;
            }
            indicator.gameObject.SetActive(false);
        }
    }

    private IEnumerator T2IndicatorRoutine()
    {
        while (true)
        {
            for (int i = 0; i < flowers.Length; i++)
            {
                if (flowers[i] == null)
                {
                    indicators[i].gameObject.SetActive(false);
                    continue;
                }
                Vector3 directionToFlower = (flowers[i].transform.position - player.transform.position).normalized;
                indicators[i].SetDesiredLocation(directionToFlower * indicatorDistanceFromPlayer + player.transform.position);
                indicators[i].SetDesiredRotation(Quaternion.LookRotation(Vector3.forward, directionToFlower));
                if(ConstantData.hatTeir > 2)
                {
                    indicators[i].transform.localScale = Vector3.one * Mathf.Clamp(1 / (Vector3.Distance(flowers[i].transform.position, player.transform.position) / 10),0.3f, 1);
                }
            }
            indicator.SetDesiredLocation((hive.transform.position - player.transform.position).normalized * indicatorDistanceFromPlayer + player.transform.position);
            indicator.SetDesiredRotation(Quaternion.LookRotation(Vector3.forward, (hive.transform.position - player.transform.position).normalized));
            yield return new WaitForSeconds(refreshRate);
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
