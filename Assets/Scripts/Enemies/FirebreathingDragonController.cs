using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebreathingDragonController : Enemy {
	float fireTimer;
	Transform target, target2;
	public GameObject projectilePrefab;
	public Transform projectileSpawnLocation;

	new void Start () {
		base.Start();
		fireTimer = 2.0f;
		target = GameHandler.instance.theDuck.transform;
		target2 = GameHandler.instance.theCatfish.transform;
	}

	new void Update(){
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
            if( Mathf.Abs(target.position.x - transform.position.x) < 12f){
                GameObject projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawnLocation.position, projectileSpawnLocation.rotation);
                
                projectile.GetComponent<FirebreathingDragonProjectileController>().Fire(target);
            }
        } else {
            target = target2;
        }
	}
}
