using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int maxTimeinSeconds;

    private float timer;
    private int timerToShow; 

    public TextMeshProUGUI timerText; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.timerToShow = (int)this.timer;
        this.timerText.text = "Time \n" + this.timerToShow; 
        
        if (this.timer > this.maxTimeinSeconds)
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().EndGame();
        }
    }
}
