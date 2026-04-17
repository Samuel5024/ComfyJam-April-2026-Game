using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeRoomActions : MonoBehaviour
{
    //collins insane ramblings: If i use delegates to pass an upgrade function to the upgrade button it might be more efficiant
    [SerializeField] string NextScene;
    [SerializeField] int hatBaseCost = 1000;
    public void LetsFlyButton()
    {
        SceneManager.LoadScene(NextScene);
    }

    public void PrintDebug(string message)
    {
        Debug.Log(message);
    }

    public void SelectChair()
    {
        Debug.Log("Chair");
    }

    public void SelectSpeedHat(int tier)
    {
        if (ConstantData.nectar >= tier * hatBaseCost)
        {
            ConstantData.nectar -= tier * hatBaseCost;
            ConstantData.hatTeir = tier;
            ConstantData.hatType = HatType.Speed;
            return;
        }
        Debug.Log("Brokey poor poor broke");
    }

    public void SelectMoneyHat(int tier)
    {
        if (ConstantData.nectar >= tier * hatBaseCost)
        {
            ConstantData.nectar -= tier * hatBaseCost;
            ConstantData.hatTeir = tier;
            ConstantData.hatType = HatType.Money;
            return;
        }
        Debug.Log("Brokey poor poor broke");
    }
    public void SelectTrackingHat(int tier)
    {
        if (ConstantData.nectar >= tier * hatBaseCost)
        {
            ConstantData.nectar -= tier * hatBaseCost;
            ConstantData.hatTeir = tier;
            ConstantData.hatType = HatType.Detection;
            return;
        }
        Debug.Log("Brokey poor poor broke");
    }
}
