using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour {

	float spawnTimer = 6f;

	public GameObject sharkPrefab;

	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 0f){
			if(GameHandler.instance.theDuck != null){
				if (Mathf.Abs(GameHandler.instance.theDuck.transform.position.x - transform.position.x) < 13f ){
					SpawnShark();
					spawnTimer = 6f;
				}
			}
		}
	}

	void SpawnShark(){
		GameObject projectile = (GameObject)Instantiate (sharkPrefab,
		 transform.position, transform.rotation);
	}
}
