using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;
    public static bool gameIsPaused;

    void OnEnable()
	{
        _playerInput = GetComponent<PlayerInput>();
        playerController = new PlayerController();
        //playerController.Player.PauseFunction.performed += PauseFunction;
    }

	public void PauseFunction(InputAction.CallbackContext context)
    {
        print("Paused");
		if (context.performed)
		{
            OnPause();
        }
        
    }

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
