using Unity.VisualScripting;
using UnityEngine;

public class MissionMaker : MonoBehaviour
{
    [SerializeField] private int flowersPerMission = 10;
    [SerializeField] private int uniqueFlowersPerMission;
    [SerializeField] private int SpawnRadius;
    [SerializeField] private GameObject[] flowerPool;
    private GameObject[] missionFlowers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        transform.localScale = transform.localScale * SpawnRadius;
        missionFlowers = new GameObject[uniqueFlowersPerMission];
        SetFlowerPool();
        SpawnFlowers();
    }

    /// <summary>
    /// Returns how many flowers are in this mission
    /// </summary>
    /// <returns></returns>
    public int GetNumMissionFlowers()
    {
        return flowersPerMission;
    }

    private void SetFlowerPool()
    {
        int arraySize = flowerPool.Length;

        //selects an item and places at the array to select from, then reducing the selection size guarenteeing it will not be selected again
        for(int i = 0; i < uniqueFlowersPerMission; i++)
        {
            int selection = UnityEngine.Random.Range(0, arraySize);
            missionFlowers[i] = flowerPool[selection];
            GameObject temp = flowerPool[selection];
            flowerPool[selection] = flowerPool[arraySize - 1];
            flowerPool[arraySize - 1] = temp;
            arraySize--;
        }
    }

    private void SpawnFlowers()
    {
        GameObject[] spawnedFlowers = new GameObject[flowersPerMission];
        int i = flowersPerMission;
        foreach (GameObject f in missionFlowers)
        {
            spawnedFlowers[i-1] = Instantiate(f, UnityEngine.Random.insideUnitCircle * SpawnRadius, Quaternion.identity);
            i--;
        }

        for(; i > 0; i--)
        {
            spawnedFlowers[i - 1] = Instantiate(missionFlowers[Random.Range(0,missionFlowers.Length)], 
                UnityEngine.Random.insideUnitCircle * SpawnRadius, Quaternion.identity);
        }

        FindAnyObjectByType<FlowerLocator>().SetFlowers(spawnedFlowers);
    }

}
