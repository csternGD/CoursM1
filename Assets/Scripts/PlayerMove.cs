using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    private bool goRight;
    private bool goLeft;

    private float moveMultiplier = 20;
    
    public Transform PlayerCam;
    public bool isGrounded;

    private float vert, hori; 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        
        if (PlayerCam == null) 
        {
            Camera cam = transform.GetComponentInChildren<Camera>();
            PlayerCam = cam.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetAxis("Horizontal") > 0)
        {
            this.goRight = true;
            this.goLeft = false; 
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            this.goLeft = true;
            this.goRight = false; 
        }
        else
        {
            this.goLeft = false;
            this.goRight = false; 
        }*/
        
        vert = Input.GetAxis("Vertical");
        hori = Input.GetAxis("Horizontal");

        //Sauve la rotation
        Quaternion lastRotation = PlayerCam.rotation;

        //Baisse / Leve la tete
        float rot = Input.GetAxis("Mouse Y") * -5;
        Quaternion q = Quaternion.AngleAxis(rot, PlayerCam.right);
        PlayerCam.rotation = q * PlayerCam.rotation;

        //Est ce qu'on  a la tete à l'envers ?
        Vector3 forwardCam = PlayerCam.forward;
        Vector3 forwardPlayer = transform.forward;
        float RegardeDevant = Vector3.Dot(forwardCam, forwardPlayer);
        
        if(RegardeDevant < 0.0f)
        {
            PlayerCam.rotation = lastRotation;
        }
        
        rot = Input.GetAxis("Mouse X") * 2;
        rb.AddTorque(Vector3.up * rot);
        q = Quaternion.AngleAxis(rot, transform.up);
        PlayerCam.rotation = q * PlayerCam.rotation;
    }

    private void FixedUpdate()
    {
        /*if (rb != null)
        {
            if (goRight)
            {
                rb.AddForce(transform.right *this.moveMultiplier);
            }

            if (this.goLeft)
            {
                rb.AddForce(-transform.right * this.moveMultiplier);
            }
        } */
        
       
        rb.AddForce(vert * transform.forward * 30);
        rb.AddForce(hori * transform.right * 30);

        // Est ce qu'on touche le sol ?
        isGrounded = false;
        RaycastHit infos;
        bool Trouve = Physics.SphereCast(transform.position + transform.up*0.1f, 0.05f, -transform.up, out infos, 2);
        if (Trouve && infos.distance < 2)
            isGrounded = true;

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * 3,ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
