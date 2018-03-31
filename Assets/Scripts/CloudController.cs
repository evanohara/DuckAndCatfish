﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

	public float cloudSpeed = 0.5f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(cloudSpeed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}