using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [Tooltip("Prefab à spawn")]
    public Transform PrefabAI;

    [Tooltip("Endroit où spawn")]
    public Transform SpawnPoint; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float time = 0;

    [Range(0, 15)] 
    [SerializeField] private float maxTime; 
    
    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time >= maxTime)
        {
            Transform ai = SpawnAI();
            //Vector3 pichenette = ai.forward * 5;
            Vector3 pichenette = new Vector3(Random.Range(-10,10),0f,Random.Range(-10,10));
           
            AddPichenette(ai,pichenette);
            time = 0;
        }
    }

    Transform SpawnAI()
    {
        Transform ai = GameObject.Instantiate<Transform>(PrefabAI);
        ai.position = SpawnPoint.position;
        ai.rotation = SpawnPoint.rotation;
        return ai; 
    }

    void AddPichenette(Transform ai, Vector3 pichenette)
    {
        Rigidbody rb = ai.GetComponent<Rigidbody>();
        rb.AddForce(-pichenette,ForceMode.Impulse);
    }
}
