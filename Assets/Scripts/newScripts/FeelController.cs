using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FeelController : MonoBehaviour
{
    private Camera cam;

    public Volume postProcessVolume; 
    
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            if (cam.fieldOfView > 60){
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 10*Time.deltaTime);
            }
            
            
        }
        else
        {
            if (cam.fieldOfView < 70)
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 70, 10 * Time.deltaTime);
            }
        }
    }
}
