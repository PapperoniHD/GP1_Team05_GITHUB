using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerDeath : MonoBehaviour
{

    [Header("Death and Respawn")] 
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private float ghostTime = 3f;
    private Collider playerCollider;
    private Rigidbody rb;
    private Transform _spawn;
    public GameObject _mesh;
    [SerializeField] private bool isDead;
    private IEnumerator _deathState;

    private bool isGhost;
    private bool deathStateRunning;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleDeath();
    }

    private void OnEnable()
    {
        isGhost = false;
        playerCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        isDead = false;
        _spawn = GameObject.FindWithTag("Spawn").transform;
        transform.position = _spawn.position;
        deathStateRunning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death") && !isGhost && GetComponent<AbilityPickup>().invincible == false)
        {
            GameObject.Find("DeathManager").GetComponent<DeathManager>().playerAlive--;
            isDead = true;
        }
        else if (other.gameObject.CompareTag("Death"))
        {
            Destroy(other.gameObject);
        }

        

    }
    
    void HandleDeath()
    {
        if (isDead)
        {
            
            _deathState = DeathState();
            if (!deathStateRunning)
            {
                StartCoroutine(_deathState);
            }
            
        }
        
    }

    private IEnumerator DeathState()
    {
        deathStateRunning = true;
        isGhost = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        _mesh.SetActive(false);
        transform.position = _spawn.position;
        
        yield return new WaitForSeconds(respawnTime);
        
        _mesh.SetActive(true);
        isDead = false;
        GameObject.Find("DeathManager").GetComponent<DeathManager>().playerAlive++;
        print("Added");
        deathStateRunning = false;
        rb.constraints = RigidbodyConstraints.None;
        
        yield return new WaitForSeconds(ghostTime);
        
        isGhost = false;
        StopCoroutine(DeathState());
    }

    
    
    
}
