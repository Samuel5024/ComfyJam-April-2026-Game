using UnityEngine;
using UnityEngine.SceneManagement;

public class HiveManager : MonoBehaviour
{
    [SerializeField] private string missionCompleteScene;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<FlowerCollector>().HasAllFlowers())
            {
                SceneManager.LoadScene(missionCompleteScene);
            }   
        }
    }
}
