using UnityEngine;
using UnityEngine.UI;

public class NectarBarController : MonoBehaviour
{
    [SerializeField] private bool heldNectar;
    [SerializeField] private int nectarCost;

    private static int MaxNectar = 5000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (heldNectar) 
        {
            gameObject.GetComponent<Image>().fillAmount = (float)ConstantData.nectar / MaxNectar;
            return;
        }
        UpdateNectarBar();
    }

    private void UpdateNectarBar()
    {
        gameObject.GetComponent<Image>().fillAmount = (float)nectarCost / MaxNectar;
    }
}
