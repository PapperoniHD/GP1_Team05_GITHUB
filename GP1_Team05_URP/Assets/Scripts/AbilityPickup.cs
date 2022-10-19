using System;
using System.Collections;
using System.Collections.Generic;
using Sounds;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    [Header("Invincibility")]
    [SerializeField]
    private float invincibilityTimer = 3;
    public bool invincible;
    public GameObject shield;

    private void Start()
    {
        invincible = false;
        shield.SetActive(false);
        
    }

    private void Update()
    {
        Abilities();
    }

    void Abilities()
    {
        if (invincible)
        {
            StartCoroutine(Invincible());
        }
    }


    private IEnumerator Invincible()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(invincibilityTimer);
        shield.SetActive(false);
        invincible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("INV"))
        {
            Destroy(other.gameObject);
            invincible = true;
            AudioManager.Instance.PlaySFX("PowerUp");
        }
    }
}
