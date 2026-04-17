using UnityEngine;

public class SetSpriteToRandomColor : MonoBehaviour
{
    private Color[] validColors = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = validColors[Random.Range(0, validColors.Length)];
    }
}
