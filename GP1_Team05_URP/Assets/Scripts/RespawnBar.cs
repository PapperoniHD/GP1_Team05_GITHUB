using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnBar : MonoBehaviour
{
    [SerializeField] private Image respawnBar1;
    [SerializeField] private Image respawnBar2;

    public GameObject player1;
    public GameObject player2;

    private float respawnTimer1;
    private float respawnTimer2;

    private DeathManager _dthMng;


    private void Start()
    {
        _dthMng = FindObjectOfType<DeathManager>().GetComponent<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        print( respawnBar1.fillAmount);
        
        if (player1 != null)
        {
            PlayerDeath restartScript1 = player1.GetComponent<PlayerDeath>();
            respawnTimer1 = restartScript1._respawnBarValue;
        }

        if (player2 != null)
        {
            PlayerDeath restartScript2 = player2.GetComponent<PlayerDeath>();
            respawnTimer2 = restartScript2._respawnBarValue;
        }
      
      
      if (_dthMng.playerOne != null)
      {
          player1 = _dthMng.playerOne;

      } else if (_dthMng.playerTwo != null)
      {
          player2 = _dthMng.playerTwo;
      }
        
        
      
        respawnBar1.fillAmount = respawnTimer1 / 2;
        respawnBar2.fillAmount = respawnTimer2 / 2;

    }
    
    
    
    
}
