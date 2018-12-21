using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{

    private Rigidbody2D rb;
	private SpriteRenderer sr;
    private Animator animator;
	public GameObject projectilePrefab, gustPrefab;
	public Transform projectileSpawnLocation;
	public AudioClip bloop, duckHit, gust;
    public float duckSpeed = 5.0f;
    public float flapSpeed = 5.0f;
    private List<DuckWeapons> weaponArsenal;
    public enum DuckWeapons { Bloop, Gust };
    private int activeWeapon;
    bool isInvul;
    float invulTimer = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isInvul = false;
        weaponArsenal = new List<DuckWeapons>();
        weaponArsenal.Add(DuckWeapons.Bloop);
        activeWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameHandler.instance.IsPaused()){
            float lh = Input.GetAxis("Horizontal1");

            if (isInvul)
            {
                invulTimer -= Time.deltaTime;
                if (invulTimer <= 0)
                {
                    isInvul = false;
                    animator.SetBool("IsInvulnerable", false);
                    invulTimer = 2.0f;
                }
            }

            if (lh > 0.1f || lh < -0.1f)
                rb.velocity = new Vector2(lh * duckSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);

            if (Input.GetButtonDown("DuckFlap"))
            {
                rb.velocity = new Vector2(lh * duckSpeed, rb.velocity.y + flapSpeed);
                Debug.Log("Flap");
            }

            if (Input.GetButtonDown("DuckDive"))
            {
                animator.SetInteger("AnimState", 1);
                rb.velocity = new Vector2(lh * duckSpeed,rb.velocity.y - flapSpeed);
                rb.gravityScale = -0.5f;
                gameObject.layer = 9;
            }

            if (Input.GetAxis("Horizontal1") > 0.1f)
            {
                sr.flipX = false;
            }
            else if (Input.GetAxis("Horizontal1") < -0.1f)
            {
                sr.flipX = true;
            }

            if (Input.GetButtonDown("DuckBloop"))
            {
                if(weaponArsenal[activeWeapon] == DuckWeapons.Bloop){
                    AudioManager.instance.PlaySingle(bloop);
                    GameObject projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawnLocation.position, projectileSpawnLocation.rotation);
                    projectile.GetComponent<DuckProjectileController>().Project(sr.flipX);
                } else if (weaponArsenal[activeWeapon] == DuckWeapons.Gust){
                    AudioManager.instance.PlaySingle(gust);
                    GameObject projectile = (GameObject)Instantiate (gustPrefab, projectileSpawnLocation.position, projectileSpawnLocation.rotation);
                    projectile.GetComponent<GustProjectileController>().Project(sr.flipX);
                }
            }

            if (Input.GetButtonDown("DuckWeaponSwap"))
            {
                Debug.Log("Weapon Swap Started!");

                activeWeapon++;
                if (activeWeapon == weaponArsenal.Count)
                {
                    activeWeapon = 0;
                }
                GameHandler.instance.SetDuckWeapon(weaponArsenal[activeWeapon]);
                Debug.Log("Weapon Swap Finished!");

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Enemy" || collider.tag == "EnemyProjectile")
        {
            if (isInvul == false){
                animator.SetBool("IsInvulnerable", true);
                isInvul = true;
                AudioManager.instance.PlaySingle(duckHit);
                GameHandler.instance.DuckGotHit();
            }
        } else if (collider.tag == "Gust"){
            weaponArsenal.Add(DuckWeapons.Gust);
        }
    }

    void OnTriggerStay2D(Collider2D collider){
    if (collider.tag == "Enemy")
        {
            if (isInvul == false){
                animator.SetBool("IsInvulnerable", true);
                isInvul = true;
                AudioManager.instance.PlaySingle(duckHit);
                GameHandler.instance.DuckGotHit();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Duck Collided with: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Airline")
        {
            animator.SetInteger("AnimState", 0);
            gameObject.layer = 8;
            rb.gravityScale = 0.5f;
        }
    }

    public void BounceUp()
    {
        rb.velocity = new Vector2(rb.velocity.x, flapSpeed);
    }
}
