using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Duck"){
			GameHandler.instance.DuckLifeUp();
			GameHandler.instance.DuckLifeUp();
			//AudioManager.instance.PlaySingle(heartSound);
            Destroy(gameObject);
        }
		if (collider.tag == "Catfish"){
			GameHandler.instance.CatfishLifeUp();
			GameHandler.instance.CatfishLifeUp();

			//AudioManager.instance.PlaySingle(heartSound);
			Destroy(gameObject);
		}
	}
}
