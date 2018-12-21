using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyDragonController : Enemy {

	float fireTimer;
	Transform target, target2;
	public GameObject projectilePrefab;
	public Transform projectileSpawnLocation;
	// Use this for initialization
	new void Start () {
		base.Start();
		fireTimer = 2.0f;
		target = GameHandler.instance.theDuck.transform;
		target2 = GameHandler.instance.theCatfish.transform;
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
	}

	void Fire(){
        if (target !=null){
            if( Mathf.Abs(target.position.x - transform.position.x) < 13f){
                GameObject projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawnLocation.position, projectileSpawnLocation.rotation);
                
                projectile.GetComponent<GreyDragonProjectile>().Fire(target);
            }
        } else {
            target = target2;
        }
	}
}
