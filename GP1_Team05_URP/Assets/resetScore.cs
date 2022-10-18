using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScore : MonoBehaviour
{
    private Score scr;

    private void Awake()
    {
        scr = FindObjectOfType<Score>().GetComponent<Score>();
    }
    public void scoreReset()
    {
        //Reset score script
        scr.playerOneScore = 0f;
        scr.playerTwoScore = 0f;
        scr.playerOne = null;
        scr.playerTwo = null;
    }
}
