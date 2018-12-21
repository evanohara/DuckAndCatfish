using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseController : MonoBehaviour {

	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.velocity = new Vector2(0.5f, 0);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "TortoiseFinishLine")
        {
			GameHandler.instance.StartEndingSequence();
        }
    }
}
