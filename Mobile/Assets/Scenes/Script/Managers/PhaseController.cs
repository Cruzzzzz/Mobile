using UnityEngine;
using System.Collections;

public class PhaseController : MonoBehaviour
{
    public PhaseManager phaseManager;
    public EnvironmentManager env;

    public void NextPhase()
    {
        StartCoroutine(ChangePhaseRoutine());
    }

    private IEnumerator ChangePhaseRoutine()
    {
        // fade entrando
        yield return ScreenFade.instance.FadeOut(1f);

        int next = phaseManager.currentPhase + 1;

        if (next < phaseManager.phases.Length)
        {
            phaseManager.ChangePhase(next);

            switch (next)
            {
                case 0: env.SetDay(); break;
                case 1: env.SetNight(); break;
                case 2: env.SetEclipse(); break;
                case 3: env.SetApocalypse(); break;
            }
        }

        // fade saindo
        yield return ScreenFade.instance.FadeIn(1f);
    }
}

