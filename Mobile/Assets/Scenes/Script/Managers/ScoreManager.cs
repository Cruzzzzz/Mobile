using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore = 0;

    public static void AddScore(int amount)
    {
        currentScore += amount;
        PlayerPrefs.SetInt("score", currentScore);
        PlayerPrefs.Save();
    }

    public static void LoadScore()
    {
        currentScore = PlayerPrefs.GetInt("score", 0);
    }
}



