using UnityEngine;
using TMPro; // Importa o TextMeshPro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float totalGameTime = 180f; // 3 minutos
    [SerializeField] private TextMeshProUGUI timerText; // Alterado pra TMP

    private float currentTime;

    private void Start()
    {
        currentTime = totalGameTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(currentTime).ToString();

        if (currentTime <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
