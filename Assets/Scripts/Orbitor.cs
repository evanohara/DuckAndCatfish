using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitor : MonoBehaviour {

	// Use this for initialization
	public Transform orbitee;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(orbitee.position, Vector3.forward, 20f * Time.deltaTime);
	}
}
