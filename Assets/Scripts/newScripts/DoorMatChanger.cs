using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMatChanger : MonoBehaviour
{
    [SerializeField] private Material[] mats;
    [SerializeField] private GameObject objectToChange;

    private HealthManager healthManager; 
    
    // Start is called before the first frame update
    void Start()
    {
        this.healthManager = gameObject.GetComponent<HealthManager>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        changeMat(this.healthManager.startHealth,this.healthManager.health);
    }

    void changeMat(int startHealth, int health)
    {

        if (health < (0.25 * startHealth))
        {
            this.objectToChange.GetComponent<MeshRenderer>().material = this.mats[2]; 
        }
        else if (health < (0.5 * startHealth) )
        {
            this.objectToChange.GetComponent<MeshRenderer>().material = this.mats[1]; 
        }else if (health < (0.75 * startHealth))
        {
            this.objectToChange.GetComponent<MeshRenderer>().material = this.mats[0]; 
            
        }
            
    }
}
