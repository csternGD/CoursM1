using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class nbrOfBullets : MonoBehaviour
{
    public int nbrOfBulletsInt;
    [SerializeField] int maxNbr,minNbr;
    private void Start()
    {
        this.nbrOfBulletsInt = Random.Range(this.minNbr, (this.maxNbr + 1)); 
    }
}
