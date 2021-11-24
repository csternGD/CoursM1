using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour
{

    public GameObject objectToSpawn; 
    public Transform surfaceForSpawn; 

    private Vector3 spawnPos; 
    private float maxXPos; 
    private float maxZPos;
    public float YPos; 

    // Start is called before the first frame update
    void Start()
    {
        maxXPos = surfaceForSpawn.localScale.x; 
        maxZPos = surfaceForSpawn.localScale.z; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Spawn();
        }
    }


    void Spawn(){
        spawnPos = new Vector3 (Random.Range(-maxXPos/2,maxXPos/2),YPos,Random.Range(-maxZPos/2,maxZPos/2));
        Instantiate(objectToSpawn,spawnPos,Quaternion.identity);
    }
}
