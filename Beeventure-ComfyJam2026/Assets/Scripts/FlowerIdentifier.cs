using UnityEngine;

public enum FlowerType
{
    None,
    Poppy,
    Daisy,
    Daffodil
}

public class FlowerIdentifier : MonoBehaviour
{
    [SerializeField] private FlowerType flowerType;

    public FlowerType GetFlowerType()
    {
        return flowerType;
    }
}
