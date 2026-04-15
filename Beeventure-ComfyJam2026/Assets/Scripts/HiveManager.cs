using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HiveManager : MonoBehaviour
{
    [SerializeField] float maxNectar;
    [SerializeField] float minNectar;
    [SerializeField] float timeToMinNectar;
    [SerializeField] private string missionCompleteScene;
    [SerializeField] private Image NectarTimer;
    private float startTime;
    private void Start()
    {
        startTime = Time.time;

        if(ConstantData.hatType == HatType.Money)
        {
            maxNectar *= ConstantData.hatTeir + 1;
            timeToMinNectar *= timeToMinNectar + 1;
        }
    }

    private void Update()
    {
        NectarTimer.fillAmount = 1 - Mathf.Clamp((Time.time - startTime) / timeToMinNectar, 0f, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<FlowerCollector>().HasAllFlowers())
            {
                Debug.Log("time (Seconds): " + (Time.time - startTime));
                Debug.Log("time Proportion: " + Mathf.Clamp((Time.time - startTime) / timeToMinNectar, 0f, 1f));
                ConstantData.nectar += Mathf.CeilToInt(Mathf.Lerp(maxNectar, minNectar, Mathf.Clamp((Time.time - startTime) / timeToMinNectar, 0f, 1f)));
                Debug.Log("Nectar: " + ConstantData.nectar);
                SceneManager.LoadScene(missionCompleteScene);
            }   
        }
    }
}
