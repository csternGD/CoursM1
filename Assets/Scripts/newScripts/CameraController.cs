using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 100f;

    public Transform player;

    public float rotationUpDown = 0f; 
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        float x = Input.GetAxis("Mouse X") * this.sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * this.sensitivity * Time.deltaTime;
        
        //manage vertical rotation
        rotationUpDown -= y;
        this.rotationUpDown = Mathf.Clamp(rotationUpDown, -90f, 90f);  //make sure the character can't look too far up or down
        transform.localRotation = Quaternion.Euler(this.rotationUpDown, 0f, 0f);
        
        //manager horizontal rotation
        this.player.Rotate(Vector3.up * x);
    }
}
