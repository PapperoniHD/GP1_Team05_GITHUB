using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScoreStorage", order = 1)]
public class ScoreStorage : ScriptableObject
{
    public float playerOneScore;
    public float playerTwoScore;
}
