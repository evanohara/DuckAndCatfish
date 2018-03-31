using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatfishController : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public AudioClip oof;
	public float catfishSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float lh = Input.GetAxis("Horizontal2");
		float lv = Input.GetAxis("Vertical2");

		if (Input.GetAxis("Horizontal2") > 0f)
		{
			sr.flipX = false;
		} else if (Input.GetAxis("Horizontal2") < 0)
		{
			sr.flipX = true;
		}

		rb.velocity = new Vector2(lh * catfishSpeed, lv * catfishSpeed);

	}

	void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Enemy")
        {
			GameHandler.instance.CatfishGotHit();
            AudioManager.instance.PlaySingle(oof);
        }
    }
}
