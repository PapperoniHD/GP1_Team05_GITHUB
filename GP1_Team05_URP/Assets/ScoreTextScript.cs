using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreTextScript : MonoBehaviour
{
    public float score;
    private TMP_Text scoreText;   
    
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        score = GameObject.Find("ScoreManager").GetComponent<Score>().playerOneScore;
        scoreText.SetText(score.ToString("F0"));
    }
    

}
