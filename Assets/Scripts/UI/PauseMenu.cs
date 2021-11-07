using Platformer.BlurredScreenshot;
using Platformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    public class PauseMenu : MonoBehaviour
    {

        [SerializeField] private BlurredBackground blurredBackground;
        [SerializeField] private Animator animator;

        public void Show()
        {
            Time.timeScale = 0;
            blurredBackground.Show();
            animator.SetBool("showing", true);
        }

        public void Hide()
        {
            Time.timeScale = 1;
            blurredBackground.Hide();
            animator.SetBool("showing", false);
        }

        #region Event Handlers

        public void BtnResumeClicked()
        {
            Hide();
        }

        public void BtnMainMenuClicked()
        {
            Simulation.Clear();
            SceneManagerExtensions.LoadSceneWithFade("Assets/Scenes/MainScene.unity");
        }

        public void BtnRestartClicked()
        {
            Simulation.Clear();
            SceneManagerExtensions.LoadSceneWithFade("Assets/Scenes/LevelScene.unity");
        }

        #endregion Event Handlers
    }
}