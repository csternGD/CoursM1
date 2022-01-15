using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int startHealth;
    [SerializeField] private string[] hurtTag;
    public deathSoundManager source;
    [SerializeField] private TextMeshProUGUI textToChange;
    public int deathSound;
    public int points;
    private ScoreManager scoreManager;
    private bool dead; 
    
    // Start is called before the first frame update
    void Start()
    {
        this.startHealth = this.health;
        source = GameObject.FindWithTag("soudManager").GetComponent<deathSoundManager>();
        this.scoreManager = GameObject.FindWithTag("scoreManager").GetComponent<ScoreManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0 && !dead)
        {
            this.source.playDeathSound(this.deathSound);
            if (gameObject.CompareTag("Player"))
            {
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().EndGame();
                dead = true;
                 
            }
            else
            {
                scoreManager.ChangeScore(points);
                if (gameObject.transform.parent)
                {
                    
                    Destroy(this.gameObject.transform.parent.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            
           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach(string tag in this.hurtTag)
        {
            if (other.CompareTag(tag))
            {
                this.health -= 1;
                if (this.textToChange)
                {
                    this.textToChange.text = "Health \n "+ this.health+"/" + this.startHealth;
                }
            }
        }
        
    }
}
