using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinAssign : MonoBehaviour
{
    private DeathManager _deathManager;
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    private void Awake()
    {
        _deathManager = FindObjectOfType<DeathManager>().GetComponent<DeathManager>();
    }

    private void Start()
    {
        //Assign player 1 and 2 to correct variable
        if (_deathManager.playerOne == null)
        {
            _deathManager.playerOne = gameObject;
        } else if (_deathManager.playerTwo == null)
        {
            _deathManager.playerTwo = gameObject;
        }

        //Assign model/skin
        if (_deathManager.playerOne == gameObject)
        {
            p1.SetActive(true);
            p2.SetActive(false);
        }
        else if (_deathManager.playerTwo == gameObject)
        {
            p1.SetActive(false);
            p2.SetActive(true);
        }
    }
}
