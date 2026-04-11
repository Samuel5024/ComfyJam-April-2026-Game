using UnityEngine;

public class FlowerCollector : MonoBehaviour
{
    [SerializeField] private int maxFlowers = 3;

    private FlowerType[] heldFlowers;
    private int flowersColected = 0;

    private void Start()
    {
        heldFlowers = new FlowerType[maxFlowers];
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
