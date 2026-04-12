using UnityEngine;

public class FlowerCollector : MonoBehaviour
{
    private int maxFlowers;
    private string[] heldFlowers;
    private int flowersColected = 0;

    private void Start()
    {
        maxFlowers = FindAnyObjectByType<MissionMaker>().GetNumMissionFlowers();
        heldFlowers = new string[maxFlowers];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Flower"))
        {
            heldFlowers[flowersColected] = collision.gameObject.GetComponent<FlowerIdentifier>().GetFlowerType();
            flowersColected++;
            Destroy(collision.gameObject);
        }
    }
}
