using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathSoundManager : MonoBehaviour
{
    public AudioSource[] sources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playDeathSound(int soundToPlay)
    {
        this.sources[soundToPlay].Play();
    }
}
