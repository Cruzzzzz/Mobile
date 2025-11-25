using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public PhaseData[] phases;
    public int currentPhase = 0;

    public void ChangePhase(int index)
    {
        currentPhase = index;
        Fish.speed = phases[index].fishSpeed;
    }
}

