using UnityEngine;
using System.Collections;

public class NextPhase : MonoBehaviour
{
    public PhaseManager phaseManager;
    public EnvironmentManager env;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Nextphase();
    }

    public void Nextphase()
    {
        StartCoroutine(ChangePhaseRoutine());
    }

    private IEnumerator ChangePhaseRoutine()
    {
        // fade entrando
        yield return ScreenFade.instance.FadeOut(2f);

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
        yield return ScreenFade.instance.FadeIn(2f);
    }
}

