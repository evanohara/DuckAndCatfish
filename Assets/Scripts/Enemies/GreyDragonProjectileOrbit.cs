using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyDragonProjectileOrbit : MonoBehaviour {

	public Transform orbitee;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(orbitee.position, Vector2.left, 20f * Time.deltaTime);
	}
}
