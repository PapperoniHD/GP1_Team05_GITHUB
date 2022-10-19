using TMPro;
using UnityEngine;

namespace ElliotsSpawnerAndShader.LeaderBoard.Scripts
{
    public class LeaderBoardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialise(LeaderBoardEntryData leaderBoardEntryData)
        {
            entryNameText.text = leaderBoardEntryData.entryName;
            entryScoreText.text = leaderBoardEntryData.entryScore.ToString();
        }
    }
}