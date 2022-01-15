using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionManager : MonoBehaviour
{
    [SerializeField] private int ammunition;
    [SerializeField] private TextMeshProUGUI ammunitionText;

    [SerializeField] private Color lowAmmunition; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void oneLessBullet()
    {
        if (this.ammunition > 0)
        {
            this.ammunition -= 1;
            this.ammunitionText.text = "Ammo \n "+ this.ammunition;
            if (this.ammunition == 5)
            {
                this.ammunitionText.color = this.lowAmmunition; 
            }
        }
        
    }

    public bool checkAmmunition()
    {
        bool canFire = this.ammunition > 0;

        return canFire; 

    }

    public void getAmmunition(int nbrToAdd)
    {
        this.ammunition += nbrToAdd; 
        this.ammunitionText.text = "Ammo \n "+ this.ammunition;
        this.ammunitionText.color = Color.white;
    }
    
    
}
