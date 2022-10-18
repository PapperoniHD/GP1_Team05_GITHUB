using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PickupSpawner : MonoBehaviour
{
    
    private int _spawnChance = 1;
    [Header("Prefab for the ability")]
    public GameObject pickUpPrefab;
    [Header("SpawnChance of the Pickup, percentage")]
    public int spawnChance = 3;

    private void OnEnable()
    {
        _spawnChance = Random.Range(0, 100);


        Transform[] childSpawns = gameObject.GetComponentsInChildren<Transform>();
        GameObject randomSpawn = childSpawns[Random.Range(0, childSpawns.Length)].gameObject;

        print(_spawnChance);
        if (_spawnChance <= spawnChance);
        {
            Instantiate(pickUpPrefab, randomSpawn.transform);
        }
    }

    private void Update()
    {
        
    }
}
