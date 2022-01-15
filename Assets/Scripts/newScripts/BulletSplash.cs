using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletSplash : MonoBehaviour
{
    public GameObject bulletParticleSystem; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "NME" || other.gameObject.CompareTag("Door"))
        {
            Instantiate(this.bulletParticleSystem, transform.position, Quaternion.Euler(-90,0,0)); 
            Destroy(this.gameObject);
        }
       
    }
}
