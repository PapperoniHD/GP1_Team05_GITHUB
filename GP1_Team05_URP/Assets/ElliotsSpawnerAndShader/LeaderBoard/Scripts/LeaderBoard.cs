using System.IO;
using UnityEngine;

namespace ElliotsSpawnerAndShader.LeaderBoard.Scripts
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private int maxScoreEntries = 10;
        [SerializeField] private Transform highscoreHolder;
        [SerializeField] private GameObject leaderboardEntryObject;

        [Header("Test")]
        [SerializeField] private LeaderBoardEntryData testEntryData = new LeaderBoardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            LeaderBoardSaveData savedScores = GetSavedScores();
            UpdateUI(savedScores);
        }
        
        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData);
        }

        public void AddEntry(LeaderBoardEntryData leaderBoardEntryData)
        {
            LeaderBoardSaveData savedScores = GetSavedScores();

            bool scoredAdded = false;

            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (leaderBoardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, leaderBoardEntryData);
                    scoredAdded = true;
                    break;
                }
            }

            if (!scoredAdded && savedScores.highscores.Count < maxScoreEntries)
            {
                savedScores.highscores.Add(leaderBoardEntryData);
            }

            if (savedScores.highscores.Count > maxScoreEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreEntries,
                    savedScores.highscores.Count - maxScoreEntries);
            }
            
            UpdateUI(savedScores);
            SaveScores(savedScores);
        }
        
        private void UpdateUI(LeaderBoardSaveData savedScores)
        {
            foreach(Transform child in highscoreHolder)
            {
                Destroy(child.gameObject);
            }

            foreach (LeaderBoardEntryData highscore in savedScores.highscores)
            {
                Instantiate(leaderboardEntryObject, highscoreHolder).
                    GetComponent<LeaderBoardEntryUI>().Initialise(highscore);
            }
        }

        private LeaderBoardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new LeaderBoardSaveData();
            }

            using(StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<LeaderBoardSaveData>(json);
            }
        }

        private void SaveScores(LeaderBoardSaveData leaderBoardSaveData)
        {
            using(StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(leaderBoardSaveData, true);
                stream.Write(json);
            }
        }
    }
}
