using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInitialForce(float initialForce, Vector3 currentForward)
    {
        this.GetComponent<Rigidbody>().AddForce(currentForward * initialForce, ForceMode.Force);
    }
}
