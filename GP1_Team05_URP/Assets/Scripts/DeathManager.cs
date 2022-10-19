using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerAlive;
    public bool gameOver;
    public bool playerSpawned;
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
            print("GAMEOVER");
            SceneManager.LoadScene(2);

            AudioManager.Instance.PlaySFX("Death");
          



        }
    }
}