using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBoy : MonoBehaviour
{
    public void LoadSpecifiedScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
