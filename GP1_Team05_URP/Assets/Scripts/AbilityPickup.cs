using System.Collections;
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
            
        }
    }


    private IEnumerator Invincible()
    {
        print("shield activated");
        shield.SetActive(true);
        yield return new WaitForSeconds(invincibilityTimer);
        
        shield.SetActive(false);
        invincible = false;
        print("shield deactivated");
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("INV"))
        {
            StopAllCoroutines();
            StartCoroutine(Invincible());
            Destroy(other.gameObject);
            invincible = true;
            AudioManager.Instance.PlaySFX("PowerUp");
        }

    }
}
