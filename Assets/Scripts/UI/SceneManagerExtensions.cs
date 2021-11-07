using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerExtensions
{
    public static void LoadSceneWithFade(string sceneName, float fadeOut = 0.05f, float fadeIn = 0.3f)
    {
        FadeEffect.FadeOut(fadeOut, () => 
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(sceneName).completed += (op) =>
            {
                FadeEffect.FadeIn(fadeIn);
            };
        });
    }
}
