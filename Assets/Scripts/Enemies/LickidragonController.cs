using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LickidragonController : Enemy {
	
	Rigidbody2D rb;
	bool triggered = false;

	new void Start(){
		base.Start();
		rb = GetComponent<Rigidbody2D>();
	}
	new void Update () {
		base.Update();
		if (!triggered){
			if (GameHandler.instance.theDuck != null && GameHandler.instance.theCatfish != null){
				if ((transform.position.x - GameHandler.instance.theCatfish.transform.position.x) < 14f || 
					(transform.position.x - GameHandler.instance.theDuck.transform.position.x) < 14f ){
					rb.velocity = new Vector2(-3f, 0f);
					rb.gravityScale = 2f;
					triggered = true;
				}
			}
			else if (GameHandler.instance.theDuck != null && GameHandler.instance.theCatfish == null){
				if ((transform.position.x - GameHandler.instance.theDuck.transform.position.x) < 14f ){
					rb.velocity = new Vector2(-3f, 0f);
					rb.gravityScale = 2f;
					triggered = true;
				}
			} 
			else if (GameHandler.instance.theDuck == null && GameHandler.instance.theCatfish != null){
				if ((transform.position.x - GameHandler.instance.theCatfish.transform.position.x) < 14f ){
					rb.velocity = new Vector2(-3f, 0f);
					rb.gravityScale = 2f;
					triggered = true;
				}
			}
		} else {
			if (rb.velocity.y > 7f){
				rb.gravityScale = 2f;
			} else if (rb.velocity.y < -7f){
				rb.gravityScale = -2f;
			}
		}
	}
}
