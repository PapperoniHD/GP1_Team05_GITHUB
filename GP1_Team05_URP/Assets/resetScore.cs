using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScore : MonoBehaviour
{
    public void scoreReset()
    {
        GameObject.Find("ScoreManager").GetComponent<Score>().playerOneScore = 0f;
    }
}
