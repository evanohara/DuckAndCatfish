using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatfishController : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public AudioClip oof, lazerSound;
	public float catfishSpeed = 5.0f;

	public GameObject lazerPrefab;
	public Transform lazerSpawnPoint;

	bool isInvul;
    float invulTimer = 2.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		isInvul = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameHandler.instance.IsPaused()){
			if (isInvul)
			{
				invulTimer -= Time.deltaTime;
				if (invulTimer <= 0)
				{
					isInvul = false;
					//animator.SetBool("IsInvulnerable", false);
					invulTimer = 2.0f;
				}
			}
			float lh = Input.GetAxis("Horizontal2");
			float lv = Input.GetAxis("Vertical2");

			if (Input.GetAxis("Horizontal2") > 0.2f)
			{
				sr.flipX = false;
			} else if (Input.GetAxis("Horizontal2") < -0.2f)
			{
				sr.flipX = true;
			}

			if (Input.GetButtonDown("CatfishLazer")){
				AudioManager.instance.PlaySingle(lazerSound);
				GameObject projectile = (GameObject)Instantiate (lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);
				projectile.GetComponent<CatfishLazerController>().Project(sr.flipX);
			}
			if (lh > 0.2f || lh < -0.2f)
				rb.velocity = new Vector2(lh * catfishSpeed, lv * catfishSpeed);
			else
				rb.velocity = new Vector2(0, lv * catfishSpeed);
		}
		

	}

	void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Enemy" || collider.tag == "EnemyProjectile")
        {
			if (isInvul == false){
                //animator.SetBool("IsInvulnerable", true);
                isInvul = true;
                AudioManager.instance.PlaySingle(oof);
                GameHandler.instance.CatfishGotHit();
            }
            
        }
    }
	void OnTriggerStay2D(Collider2D collider){
    if (collider.tag == "Enemy")
        {
            if (isInvul == false){
                //animator.SetBool("IsInvulnerable", true);
                isInvul = true;
                AudioManager.instance.PlaySingle(oof);
                GameHandler.instance.CatfishGotHit();
            }
        }
    }
}
