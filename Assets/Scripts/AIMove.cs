using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{

    public Rigidbody rb;
    public float multiplier;

    private bool goFast;

    private Animator animController; 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.animController = this.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            goFast = true;
        }
        else
        {
            goFast = false;
        }


    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            if (goFast)
            {
                this.rb.AddForce(transform.forward * this.multiplier,ForceMode.Force);
            }
        }

        if (this.animController != null)
        {
            this.animController.SetFloat("walkSpeed",this.rb.velocity.magnitude);
        }
    }
}
