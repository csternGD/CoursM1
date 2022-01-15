using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public GameObject lastBulletSpawn;
    public float projectionForce; 
    
    public Transform SpawnPos;

    public float spawnRate;

    private float timer;

    [SerializeField]private AudioSource ShootaudioSource;
    [SerializeField]private AudioSource NoShootaudioSource;

    public ParticleSystem NozzleSpritz;

    public Animator sprayBottleAnimator;

    private AmmunitionManager amManager; 
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.amManager = this.GetComponent<AmmunitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.amManager.checkAmmunition())
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastBulletSpawn = Instantiate(this.bullet, this.SpawnPos.position, Quaternion.identity);
                this.lastBulletSpawn.GetComponent<BulletMovement>().AddInitialForce(this.projectionForce, transform.forward);
                this.timer = this.spawnRate;
                this.ShootaudioSource.Play();
                this.NozzleSpritz.Play();
                this.sprayBottleAnimator.SetTrigger("shoot");
                this.amManager.oneLessBullet();
            }
            else if (Input.GetMouseButton(0))
            {
                timer -= Time.deltaTime;
                if (this.timer <= 0)
                {
                    lastBulletSpawn = Instantiate(this.bullet, this.SpawnPos.position, Quaternion.identity);
                    this.lastBulletSpawn.GetComponent<BulletMovement>().AddInitialForce(this.projectionForce, transform.forward);
                    this.timer = this.spawnRate; 
                    this.ShootaudioSource.Play();
                    this.NozzleSpritz.Play();
                    this.sprayBottleAnimator.SetTrigger("shoot");
                    this.amManager.oneLessBullet();
                }
            }
        }else if (Input.GetMouseButtonDown(0))
        {
            this.NoShootaudioSource.Play();
        }
        
    }
}
