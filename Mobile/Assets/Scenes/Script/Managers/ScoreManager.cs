using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore;

    public static void AddScore(int amount)
    {
        currentScore += amount;
    }
}

