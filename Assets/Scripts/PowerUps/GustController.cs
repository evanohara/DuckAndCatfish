using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustController : MonoBehaviour {

	public AudioClip powerUp;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Duck"){
			AudioManager.instance.PlaySingle(powerUp);
            Destroy(gameObject);
        }
	}
}
