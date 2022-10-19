
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerAlive;
    public bool gameOver;
    public bool playerSpawned;
    public float gameOverDelay = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive <= 0 && playerSpawned)
        {
            gameOver = true;
            
            AudioManager.Instance.PlaySFX("Death");
            StartCoroutine(GameOver());
            GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>().globalSpeed = 0;
        }
    }

    private IEnumerator GameOver()
    {   
        playerOne.GetComponent<PlayerDeath>()._respawnBarValue = 0;
        playerOne.SetActive(false);
        if (playerTwo != null)
        {
            playerTwo.GetComponent<PlayerDeath>()._respawnBarValue = 0;
            playerTwo.SetActive(false);
        }
        
        
        
        print("GAMEOVER");
        
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene(2);
        
    }
    
    
}
