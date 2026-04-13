using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeRoomActions : MonoBehaviour
{
    //collins insane ramblings: If i use delegates to pass an upgrade function to the upgrade button it might be more efficiant
    [SerializeField] string NextScene;
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
}
