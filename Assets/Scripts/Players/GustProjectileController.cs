using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustProjectileController : MonoBehaviour {

	Rigidbody2D rb;
	float destroTimer = 1.0f;

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
			rb.velocity = new Vector2(-10f, 0);
		}
		else
		{
			rb.velocity = new Vector2(10f, 0);
		}

	}
}
