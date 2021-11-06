using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    const string RESOURCE_NAME = "UI/FadeEffect";

    static float val;

    public CanvasGroup canvasGroup;

    public static FadeEffect instance;

    [RuntimeInitializeOnLoadMethod]
    static void Create()
    {
        instance = Instantiate((GameObject)Resources.Load(RESOURCE_NAME)).GetComponent<FadeEffect>();

        DontDestroyOnLoad(instance.gameObject);
    }

    private void Update()
    {
        canvasGroup.alpha = val;
        AudioListener.volume = Mathf.Clamp(-val + 1f, 0f, 1f);
    }

    public static void FadeIn(float time)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(DoFadeIn(time));
    }

    public static void FadeOut(float time)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(DoFadeOut(time));
    }

    public static void FadeOutAndIn(float fadeOut, float fadeIn)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(DoFadeOutAndIn(fadeOut, fadeIn));
    }

    static IEnumerator DoFadeIn(float time)
    {
        val = 1f;
        while(val > 0f)
        {
            val -= Time.unscaledDeltaTime / time;
            yield return null;
        }
    }

    static IEnumerator DoFadeOut(float time)
    {
        val = 0f;
        while (val < 1f)
        {
            val += Time.unscaledDeltaTime / time;
            yield return null;
        }
    }

    static IEnumerator DoFadeOutAndIn(float fadeOut, float fadeIn)
    {
        instance.StartCoroutine(DoFadeOut(fadeOut));
        yield return new WaitForSecondsRealtime(fadeOut);
        instance.StartCoroutine(DoFadeIn(fadeIn));
    }
}
