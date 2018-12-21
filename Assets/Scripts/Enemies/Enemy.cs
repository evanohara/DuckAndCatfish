using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int hitpoints;
	public List<DropItem> dropTable;

	float hitTimer;
	float blinkTimer;

	SpriteRenderer spriteRenderer;

	static float BLINKTIME = 0.05f;
	static float HITTIME = 0.3f;

	bool recentlyGotHit;
	bool isRed;

	public void Start(){
		recentlyGotHit = false;
		spriteRenderer = GetComponent<SpriteRenderer>();
		hitTimer = HITTIME;
		blinkTimer = BLINKTIME;
		isRed = false;
	}

	public void Update(){
		if (recentlyGotHit){
			hitTimer -= Time.deltaTime;
			blinkTimer -= Time.deltaTime;
			if (hitTimer < 0f){
				SetColorToNormal();
				recentlyGotHit = false;
				hitTimer = HITTIME;
				blinkTimer = BLINKTIME;
			} else {
				if (blinkTimer < 0f){
					if (isRed){
						SetColorToNormal();
					} else {
						SetToRedColor();
					}
					blinkTimer = BLINKTIME;
				}
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "PlayerWeapon"){
			AudioManager.instance.PlayGenericHitSound();
			hitTimer = HITTIME;
			hitpoints--;
			recentlyGotHit = true;
			if (hitpoints <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

	void SetToRedColor(){
		spriteRenderer.color = new Color(1, 0, 0, 1);
		isRed = true;
	}

	void SetColorToNormal(){
		spriteRenderer.color = new Color(1, 1, 1, 1);
		isRed = false;
	}

}
