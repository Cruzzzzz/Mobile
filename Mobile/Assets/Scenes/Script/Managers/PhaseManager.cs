using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public PhaseData[] phases;
    public int currentPhase = 0;

    public void ChangePhase(int index)
    {
        currentPhase = index;

        // Novo jeito recomendado pelo Unity
        Fish[] allFish = FindObjectsByType<Fish>(FindObjectsSortMode.None);

        Fish.globalSpeed = phases[index].fishSpeed;


    }
}

