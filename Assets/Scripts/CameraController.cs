using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 target;

	float targetX;

	public Transform duckTransform, catfishTransform;

	// Use this for initialization
	void Start () {
		targetX = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (duckTransform != null && catfishTransform != null){
			targetX = (duckTransform.position.x + catfishTransform.position.x) /2f;
			
		} else if (duckTransform == null)
		{
			targetX = catfishTransform.position.x;
		} else {
			targetX = duckTransform.position.x;
		}
		gameObject.transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}
}
