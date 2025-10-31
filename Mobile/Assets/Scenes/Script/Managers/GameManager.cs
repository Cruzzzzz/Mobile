using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float totalGameTime = 180f; // 3 minutos
    [SerializeField] private Text timerText;
    [SerializeField] private AreaManager areaManager;
    private float currentTime;

    private void Start()
    {
        currentTime = totalGameTime;
        areaManager.ChangeArea(0);
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(currentTime).ToString();

        if (currentTime <= 0)
        {
            SceneManager.LoadScene("Menu");
        }

        areaManager.UpdateAreaByTime(totalGameTime - currentTime);
    }
}
