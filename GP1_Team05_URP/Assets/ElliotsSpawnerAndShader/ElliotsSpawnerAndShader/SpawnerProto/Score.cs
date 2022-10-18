using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public float playerOneScore;
    public float playerTwoScore;
    public GameObject playerOne;
    public GameObject playerTwo;

    private Scene currentScene;
    private DeathManager _dthMng;
    
    [SerializeField] private ScoreStorage _scrStrg;
    [SerializeField] private float _scoreIncrease;
    private void Awake()
    {
        _dthMng = FindObjectOfType<DeathManager>().GetComponent<DeathManager>();
    }

    private void Update()
    {
        AssignPLayers();
        
        currentScene = SceneManager.GetActiveScene();

        if (playerOne != null && !playerOne.GetComponent<PlayerDeath>().isDead)
        {
            playerOneScore += _scoreIncrease * Time.deltaTime;
        }

        if (playerTwo != null && !playerTwo.GetComponent<PlayerDeath>().isDead)
        {
            playerTwoScore += _scoreIncrease * Time.deltaTime;
        }

        //Update score to scoreStorage
        //P1
        if (_scrStrg.playerOneScore != playerOneScore) _scrStrg.playerOneScore = playerOneScore;
        //P2
        if (_scrStrg.playerTwoScore != playerTwoScore) _scrStrg.playerTwoScore = playerTwoScore;

    }
    
    private void AssignPLayers()
    {
        if (playerOne == null)
        {
            playerOne = _dthMng.playerOne;
        }
        else if (playerTwo == null)
        {
            playerTwo = _dthMng.playerTwo;
        }
    }
}
