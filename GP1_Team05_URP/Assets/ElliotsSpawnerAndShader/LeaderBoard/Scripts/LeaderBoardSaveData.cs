using System;
using System.Collections.Generic;

namespace ElliotsSpawnerAndShader.LeaderBoard.Scripts
{
    [Serializable]
    public class LeaderBoardSaveData
    {
        public List<LeaderBoardEntryData> highscores = new List<LeaderBoardEntryData>();
    }
}
