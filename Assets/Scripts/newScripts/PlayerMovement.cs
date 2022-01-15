using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveForward;
    private float moveSide;
    private float moveUp;

    private bool isGrounded;

    [Header("Walk")]
    public float walkSpeed = 1f;
    public float sprintSpeed;

    private float currentSpeed;
  
    [Header("Jump")]
    public float jumpSpeed = 5f;

    private Rigidbody rb;

    [SerializeField] private AmmunitionManager amuManager;
    private AudioSource source; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (this.currentSpeed != this.sprintSpeed)
            {
                this.currentSpeed = this.sprintSpeed;
            }
        }
        else
        {
            this.currentSpeed = this.walkSpeed; 
        }
        
        this.moveForward = Input.GetAxis("Vertical") * this.currentSpeed;
        this.moveSide = Input.GetAxis("Horizontal") * this.currentSpeed;
        this.moveUp = Input.GetAxis("Jump") * this.jumpSpeed; 
    }

    private void FixedUpdate()
    {
        this.rb.velocity = (transform.forward * this.moveForward) + (transform.right * this.moveSide) +
                           (transform.up * this.rb.velocity.y);

        if (this.isGrounded && this.moveUp != 0)
        {
            this.rb.AddForce(transform.up * this.moveUp, ForceMode.VelocityChange);
            this.isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            this.isGrounded = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammunition"))
        {
            this.source.Play();
            this.amuManager.getAmmunition(other.GetComponent<nbrOfBullets>().nbrOfBulletsInt);
            Destroy(other.gameObject);
        }
    }
}
