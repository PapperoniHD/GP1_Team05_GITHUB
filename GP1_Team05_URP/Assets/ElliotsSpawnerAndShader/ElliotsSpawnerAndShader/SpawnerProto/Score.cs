using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public float playerOneScore;
    public float playerTwoScore;

    private Scene currentScene;
    
    [SerializeField] private float _scoreIncrease;
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (currentScene.name == "Gabriel_PlayScene")
        {
            playerOneScore = 0;
        }
    }

    private void Update()
    {

        currentScene = SceneManager.GetActiveScene();

        

       /* if (GameObject.Find("DeathManager").GetComponent<DeathManager>().gameOver != true)
        {
            
        }*/
        
        playerOneScore += _scoreIncrease * Time.deltaTime;
        //print(Mathf.Ceil(playerOneScore).ToString());
       
    }
}
