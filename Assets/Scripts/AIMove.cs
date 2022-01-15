using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIMove : MonoBehaviour
{
    
    [SerializeField] private Rigidbody rb;
    
    [Tooltip("Vitesse de déplacement"), Range(1,20)]
    [SerializeField] private float moveMultiplier = 20;
    
    [Tooltip("Vitesse de rotation"), Range(1,15)]
    [SerializeField] private float torqueMultiplier = 10;
    
    private bool goFast = false;
    private bool turnAround = false;
    private int move, rotate, direction;

    private Animator animController;

    private Transform player; 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.animController = this.GetComponent<Animator>();
        GameObject goPlayer = GameObject.FindWithTag("Player");
        player = goPlayer.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        move = Random.Range(0,2);
        rotate = Random.Range(0, 2);
        direction = Random.Range(0, 100);
        
        if (move == 0)
        {
            goFast = true;
        }
        else 
        {
            goFast = false;
        }
        
        
        if (rotate == 0)
        {
            turnAround = true; 
        }
        else 
        {
            turnAround = false; 
        }

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            if (goFast && rb.velocity.magnitude < 1)
            {
                this.rb.AddForce(-transform.forward * this.moveMultiplier,ForceMode.Force);
            }

            if (this.turnAround && this.rb.angularVelocity.magnitude < 2)
            {
                if (this.direction <= 30)
                {
                    this.rb.AddTorque((transform.up * torqueMultiplier));
                }
                else
                {
                    this.rb.AddTorque((transform.up * -torqueMultiplier));
                }
                
            }
        }

        if (this.animController != null)
        {
            this.animController.SetFloat("walkSpeed",this.rb.velocity.magnitude);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("NME"))
        {
            Destroy(this.gameObject);
        }
    }
}


