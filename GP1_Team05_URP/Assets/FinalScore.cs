using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public float score1;
    public float score2;
    private TMP_Text scoreText;

    [SerializeField] private ScoreStorage _scrStrg;

    // Start is called before the first frame update
    void Start()
    {
        score1 = _scrStrg.playerOneScore;
        score2 = _scrStrg.playerTwoScore;

        scoreText = GetComponent<TMP_Text>();
        scoreText.SetText((score1 + score2).ToString("F0"));
    }

 
}
