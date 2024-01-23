using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EchoShellVR.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private string mainScenePath;
        
        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClick);
            quitButton.onClick.AddListener(QuitButtonClick);
        }
        
        private void PlayButtonClick()
        {
            SceneManager.LoadScene(mainScenePath);
        }

        private void QuitButtonClick()
        {
            Application.Quit();
        }
    }
}
