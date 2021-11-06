using Platformer.Model;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class MainMenuCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputUsername;
        [SerializeField] private Button btnPlay;

        private static MainMenuCanvas _instance;
        public static MainMenuCanvas Instance => _instance;

        void Awake()
        {
            if (_instance == null) _instance = this;

            inputUsername.onValueChanged.AddListener(OnUsernameInputChanged);
            inputUsername.text = GameDatabase.Instance.CurrentUser.Username;

            CheckBtnInteractable(inputUsername.text);
        }

        private void OnDestroy()
        {
            inputUsername.onValueChanged.RemoveListener(OnUsernameInputChanged);
        }

        /// <summary>
        /// Checks if the button can be interacted with. The button will be disabled if the username field is empty
        /// </summary>
        /// <param name="name"></param>
        private void CheckBtnInteractable(string name)
        {
            btnPlay.interactable = !string.IsNullOrEmpty(name);
        }

        #region Event Handlers

        private void OnUsernameInputChanged(string newName)
        {
            GameDatabase.Instance.SetUsername(newName);

            CheckBtnInteractable(newName);
        }

        public void BtnPlayClicked()
        {
            SceneManager.LoadScene("Assets/Scenes/LevelScene.unity", LoadSceneMode.Single);
        }
        
        #endregion Event Handlers
    }
}