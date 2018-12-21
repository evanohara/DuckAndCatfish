using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckProjectileController : MonoBehaviour {

	Rigidbody2D rb;
	float destroTimer = 0.4f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		destroTimer -= Time.deltaTime;
		if (destroTimer < 0)
			Destroy(gameObject);
	}

	public void Project(bool flipped){
		rb = GetComponent<Rigidbody2D>();
		if (flipped)
		{
			rb.velocity = new Vector2(-20f, 0);
		}
		else
			rb.velocity = new Vector2(20f, 0);

	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Enemy"){
			Destroy(gameObject);
		}
	}
}
