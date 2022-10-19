using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Scripts
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        public static bool gameIsPaused;

        public void StartGame()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Leaderboard()
        {
            SceneManager.LoadScene(3);
        }

        public void OnPause()
        {
            print("Pause");
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        public void PauseGame()
        {
            if (gameIsPaused)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }
}
