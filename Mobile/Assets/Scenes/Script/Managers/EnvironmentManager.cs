using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnvironmentManager : MonoBehaviour
{
    public Light2D globalLight;
    public float fadeSpeed = 2f;

    public void SetDay()
    {
        globalLight.intensity = 1f;
        globalLight.color = Color.white;
    }

    public void SetNight()
    {
        globalLight.intensity = 0.3f;
        globalLight.color = new Color(0.3f, 0.3f, 0.6f);
    }

    public void SetEclipse()
    {
        globalLight.intensity = 0.1f;
        globalLight.color = Color.black;
    }

    public void SetApocalypse()
    {
        globalLight.intensity = 0.4f;
        globalLight.color = Color.red;
    }
}

