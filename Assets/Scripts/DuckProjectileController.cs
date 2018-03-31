using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckProjectileController : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
