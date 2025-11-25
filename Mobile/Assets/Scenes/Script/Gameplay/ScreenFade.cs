using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade instance;

    private CanvasGroup cg;

    private void Awake()
    {
        instance = this;
        cg = GetComponent<CanvasGroup>();
    }

    public IEnumerator FadeOut(float speed = 1f)
    {
        while (cg.alpha < 1f)
        {
            cg.alpha += Time.deltaTime * speed;
            yield return null;
        }
    }

    public IEnumerator FadeIn(float speed = 1f)
    {
        while (cg.alpha > 0f)
        {
            cg.alpha -= Time.deltaTime * speed;
            yield return null;
        }
    }
}
