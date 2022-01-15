using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public PlayerMovement player;
    public Shooter playershoot;
    public GameObject weaponVisual; 
    public GameObject endScreenCanvas; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name); 
        }
    }

    public void EndGame()
    {
        this.player.enabled = false; 
        this.playershoot.enabled = false; 
        this.weaponVisual.SetActive(false);
        this.endScreenCanvas.SetActive(true);
    }
    
    
}
