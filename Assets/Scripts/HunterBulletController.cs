using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBulletController : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-20f, 0);
	}
}
