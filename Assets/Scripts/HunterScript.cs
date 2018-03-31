using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour {

	public GameObject bulletPrefab;

	public Transform bulletSpawnLocation;
	public AudioClip gunshot, scream, punch;
    private Animator animator;
    public int hitpoints = 2;
    bool hurting;

	float fireTimer;
    float hurtTimer;

	// Use this for initialization
	void Start () {
		fireTimer = 2.0f;
        hurtTimer = 0.5f;
        hurting = false;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer -= Time.deltaTime;
         if(fireTimer < 0)
         {
             Fire();
			 fireTimer = 2.0f;
         }
         if (hurting == true)
         {
             hurtTimer -= Time.deltaTime;
             if (hurtTimer <= 0)
             {
                 hurting = false;
                 animator.SetBool("JustGotHurt", false);
                 hurtTimer = 0.5f;

             }
         }
	}

	void Fire(){
		AudioManager.instance.PlaySingle(gunshot);
		GameObject projectile = (GameObject)Instantiate (bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
		projectile.GetComponent<HunterBulletController>().Fire();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "PlayerWeapon"){
            hitpoints--;
            if (hitpoints <= 0)
            {
                AudioManager.instance.PlaySingle(scream);
                Destroy(gameObject);
            }
            else
            {
                hurting = true;
                animator.SetBool("JustGotHurt", true);
                AudioManager.instance.PlaySingle(punch);
            }
		}
	}
}
