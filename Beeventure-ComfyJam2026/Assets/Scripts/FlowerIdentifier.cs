using UnityEngine;

public class FlowerIdentifier : MonoBehaviour
{
    [SerializeField] private string flowerType;

    public string GetFlowerType()
    {
        return flowerType;
    }
}
