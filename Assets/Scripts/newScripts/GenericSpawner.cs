using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenericSpawner : MonoBehaviour
{
    [SerializeField] private GameObject thingToSpawn;
    private float spawnScaleX,spawnScaleZ;
    [SerializeField] private Transform spawnZone;

    [SerializeField] private int spawnRate;

    private float timer;


    private void Start()
    {
        this.spawnScaleX = this.spawnZone.localScale.x/2;
        this.spawnScaleZ = this.spawnZone.localScale.z/2;

        this.spawnScaleX -= this.thingToSpawn.transform.localScale.x;
        this.spawnScaleZ -= this.thingToSpawn.transform.localScale.z; 

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= this.spawnRate)
        {
            this.SpawnThing();
            timer = 0;
        }
    }

    void SpawnThing()
    {
        Vector3 placeOfSpawn = new Vector3((Random.Range(-this.spawnScaleX, this.spawnScaleX)), 0,
            (Random.Range(-this.spawnScaleZ, this.spawnScaleZ)));
        
        Instantiate(thingToSpawn,placeOfSpawn,quaternion.identity); 

    }
    
    
    
    
    
}
