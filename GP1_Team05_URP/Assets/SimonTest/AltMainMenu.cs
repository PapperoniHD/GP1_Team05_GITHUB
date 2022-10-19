using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimonTest
{
    public class AltMainMenu : MonoBehaviour
    {
        public void AltPlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
