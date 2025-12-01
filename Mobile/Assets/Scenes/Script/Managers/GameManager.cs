using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float totalGameTime = 180f;
    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTime;
    private bool isPaused;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        currentTime = PlayerPrefs.GetFloat("SavedTime", totalGameTime);
        ScoreManager.LoadScore();
        isPaused = false;
        Time.timeScale = 1f;
        UpdateTimerTextImmediate();
    }

    private void OnEnable()
    {
        if (Instance == this && !isPaused)
            Time.timeScale = 1f;
    }

    private void Update()
    {
        if (isPaused) return;

        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f) currentTime = 0f;
            UpdateTimerTextImmediate();
        }

        if (currentTime <= 0f)
        {
            PlayerPrefs.DeleteKey("SavedTime");
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    private void UpdateTimerTextImmediate()
    {
        if (timerText != null)
            timerText.text = Mathf.CeilToInt(currentTime).ToString();
    }

    public void PauseGameAndSave()
    {
        if (isPaused) return;
        isPaused = true;
        PlayerPrefs.SetFloat("SavedTime", currentTime);
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        Debug.Log("[GameManager] Paused and saved time: " + currentTime);
    }

    public void ResumeGame()
    {
        if (!isPaused) return;
        isPaused = false;
        Time.timeScale = 1f;
        Debug.Log("[GameManager] Resumed. Current time: " + currentTime);
    }

    public float GetCurrentTime() => currentTime;
}
