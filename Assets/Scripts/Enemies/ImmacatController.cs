using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmacatController : MonoBehaviour {

	float attackTimer = 3f;
	float lungeTimer = 1f;
	bool attackReady;
	bool attacking;

	public AudioClip hiya;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		attackReady = true;
		attacking = false;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackReady)
		{
			attackReady = false;
			AudioManager.instance.PlaySingle(hiya);
			rb.velocity = new Vector2(0f, 10f);
			attacking = true;
		}
		if (attacking){
			lungeTimer -= Time.deltaTime;
			if (lungeTimer < 0){
				if (GameHandler.instance.theDuck.transform.position.x > transform.position.x)
					rb.velocity = new Vector2(10f, rb.velocity.y);
				else
					rb.velocity = new Vector2(-10f, rb.velocity.y);
				attacking = false;
			}
		}
		if (attackTimer < 0){
			
		}
	}
}
