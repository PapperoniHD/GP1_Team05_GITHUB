using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerDeath : MonoBehaviour
{

    [Header("Death and Respawn")] 
    [SerializeField] public float respawnTime = 2f;
    [SerializeField] private float ghostTime = 3f;
    private Collider playerCollider;
    private Rigidbody rb;
    private Transform _spawn;
    private IEnumerator _deathState;

    public bool isDead;
    public GameObject _mesh;
    
    private bool isGhost;
    private bool deathStateRunning;

    public float _respawnBarValue;
    private DeathManager _deathManager;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _respawnBarValue = respawnTime;
        _deathManager = FindObjectOfType<DeathManager>().GetComponent<DeathManager>();
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDeath();
        RespawnBarTime();
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
            isDead = true;
            audioManager.PlaySFX("Death");
        }
        
        if (other.gameObject.CompareTag("Death") && GetComponent<AbilityPickup>().invincible)
        {
            Destroy(other.gameObject);
        }

        

    }
    
    void HandleDeath()
    {

        if (_deathManager.gameOver == false)
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
        else
        {
            StopAllCoroutines();
            _respawnBarValue = 0;
            deathStateRunning = true;
            isGhost = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            _mesh.SetActive(false);
        }
        
        
        

    }
    
    void RespawnBarTime()
    {
        if (isDead)
        {
            _respawnBarValue += Time.deltaTime;

            if (_respawnBarValue >= respawnTime)
            {
                _respawnBarValue = respawnTime;
            }
        }
    }
    

    private IEnumerator DeathState()
    {
        GameObject.Find("DeathManager").GetComponent<DeathManager>().playerAlive--;
        _respawnBarValue = 0;
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
