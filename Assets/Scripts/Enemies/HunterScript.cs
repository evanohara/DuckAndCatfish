using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : Enemy {

	public GameObject bulletPrefab;

	public Transform bulletSpawnLocation;
    public Transform target, target2;
	public AudioClip gunshot, scream, punch;
    //private Animator animator;

    bool hurting;

	float fireTimer;
    float hurtTimer;

	// Use this for initialization
	new void Start () {
        base.Start();
		fireTimer = 2.0f;
        hurtTimer = 0.5f;
        hurting = false;
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
		fireTimer -= Time.deltaTime;
         if(fireTimer < 0)
         {
             Fire();
			 fireTimer = Random.Range( 1.5f, 3.0f);
         }
         if (hurting == true)
         {
             hurtTimer -= Time.deltaTime;
             if (hurtTimer <= 0)
             {
                 hurting = false;
                 //animator.SetBool("JustGotHurt", false);
                 hurtTimer = 0.5f;

             }
        }
	}

	void Fire(){
        if (target !=null){
            if( Mathf.Abs(target.position.x - transform.position.x) < 12f){
                AudioManager.instance.PlaySingle(gunshot);
                GameObject projectile = (GameObject)Instantiate (bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
                
                projectile.GetComponent<HunterBulletController>().Fire(target);
            }
        } else {
            target = target2;
        }
	}

    new void OnTriggerEnter2D(Collider2D collider){
        base.OnTriggerEnter2D(collider);
		if (collider.tag == "PlayerWeapon"){
            if (hitpoints <= 0)
            {
                AudioManager.instance.PlaySingle(scream);
            }
		}
	}


}
