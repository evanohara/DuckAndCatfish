using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyDragonProjectile : MonoBehaviour {

	public GameObject orbitor;
	public float speed;
	Rigidbody2D rb;

	public void Fire (Transform target) {
		rb = GetComponent<Rigidbody2D>();
		Vector2 heading = target.position - transform.position;
		float distance = heading.magnitude;
		Vector2 direction = heading/distance;
		rb.velocity = direction * 2f;
	}
	void Update () {
		OrbitAround();
		orbitor.transform.rotation = Quaternion.Euler(Vector3.zero);
	}

	void OrbitAround(){
		Debug.Log("Rotatorrr!");
		//orbitor.transform.position = RotatePointAroundPivot(orbitor.transform.position, transform.position, Quaternion.Euler(0, 0, angle));
		orbitor.transform.RotateAround(transform.position, Vector3.forward, 200f * Time.deltaTime);
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
         return angle * ( point - pivot) + pivot;
     }
}
