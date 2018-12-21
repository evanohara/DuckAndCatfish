using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebreathingDragonProjectileController : MonoBehaviour {

	Rigidbody2D rb;

	public void Fire (Transform target) {
		rb = GetComponent<Rigidbody2D>();
		Vector2 heading = target.position - transform.position;
		float distance = heading.magnitude;
		Vector2 direction = heading/distance;
		rb.velocity = direction * 8f;
	}
}
