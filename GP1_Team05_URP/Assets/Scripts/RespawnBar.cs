using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnBar : MonoBehaviour
{
    [SerializeField] private Image respawnBar1;
    [SerializeField] private Image respawnBar2;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private float respawnTimer1;
    private float respawnTimer2;

    // Update is called once per frame
    void Update()
    {     
        PlayerDeath restartScript1 = player1.GetComponent<PlayerDeath>();
        respawnTimer1 = restartScript1.respawnTime;

        PlayerDeath restartScript2 = player2.GetComponent<PlayerDeath>();
        respawnTimer2 = restartScript2.respawnTime;

        respawnBar1.fillAmount = respawnTimer1 / 2f;
        respawnBar2.fillAmount = respawnTimer2 / 2f;

    }
}
