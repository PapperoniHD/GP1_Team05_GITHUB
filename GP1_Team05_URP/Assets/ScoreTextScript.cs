using System.Collections;
using System.Collections.Generic;
using ElliotsSpawnerAndShader.ElliotsSpawnerAndShader.SpawnerProto;
using UnityEngine;
using TMPro;
public class ScoreTextScript : MonoBehaviour
{
    public float score1;
    public float score2;
    private TMP_Text scoreText1;
    private TMP_Text scoreText2;

    [SerializeField] private ScoreStorage _scrStrg;

    // Start is called before the first frame update
    void Start()
    {
        
        scoreText1 = GameObject.Find("Score1").GetComponent<TMP_Text>();
        scoreText2 = GameObject.Find("Score2").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score1 = _scrStrg.playerOneScore;
        scoreText1.SetText(score1.ToString("F0"));

        score2 = _scrStrg.playerTwoScore;
        scoreText2.SetText(score2.ToString("F0"));
    }
    

}
