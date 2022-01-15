using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMove : MonoBehaviour
{
    public Transform playerCam;

    // Start is called before the first frame update
    void Start()
    {
        if (playerCam == null)
        {
            Camera cam = transform.GetComponentInChildren<Camera>();
            playerCam = cam.transform;
        }
    }

    private void Update()
    {
        //Sauve la rotation
        Quaternion lastRotation = playerCam.rotation;

        //Baisse / leve la tete
        float rot = Input.GetAxis("Mouse Y") * -10;
        Quaternion q = Quaternion.AngleAxis(rot,playerCam.right);
        playerCam.rotation = q * playerCam.rotation;

        //Est ce qu'on a la tete à l'envers ?
        Vector3 forwardCam = playerCam.forward;
        Vector3 forwardPlayer = transform.forward;
        float regardeDevant = Vector3.Dot(forwardCam, forwardPlayer);
        if(regardeDevant < 0.0f)
            playerCam.rotation = lastRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();

        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        rb.AddForce(vert * transform.forward * 30);
        rb.AddForce(hori * transform.right * 30);

        float rot = Input.GetAxis("Mouse X") * 10;
        rb.AddTorque(Vector3.up * rot);
    }
}
