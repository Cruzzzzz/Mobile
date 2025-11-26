using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour
{
    public PhaseData[] phases;
    public int currentPhase = 0;

    public int pointsPerPhase = 100; // agora troca a cada 100 pontos

    void Update()
    {
        int playerScore = ScoreManager.currentScore;
        int targetPhase = playerScore / pointsPerPhase;

        if (targetPhase != currentPhase && targetPhase < phases.Length)
        {
            ChangePhase(targetPhase);
        }
    }

    public void ChangePhase(int index)
    {
        currentPhase = index;

        // Novo método recomendado pelo Unity
        Fish[] allFish = FindObjectsByType<Fish>(FindObjectsSortMode.None);

        // Exemplo: altera velocidade global dos peixes
        Fish.globalSpeed = phases[index].fishSpeed;

        Debug.Log("Trocou para fase: " + index);
    }
}

