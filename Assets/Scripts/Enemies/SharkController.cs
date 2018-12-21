using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : Enemy {

	Transform attackTarget;
    private Animator animator;
    private float jetAttackTimer = 3f;
    private float jetAttackDuration = 0.5f;
    private bool jetAttackReady;
    private bool jetAttacking;
    public DropItem myItem;
    public int gayPoints;

	// Use this for initialization
	new void Start () {
        base.Start();
        PopulateDropTable();
		jetAttackReady = true;
        jetAttacking = false;
        animator = GetComponent<Animator>();
        if(GameHandler.instance.theCatfish != null)
            attackTarget = GameHandler.instance.theCatfish.transform;
        else
            attackTarget = GameHandler.instance.theDuck.transform;
	}
	
	// Update is called once per frame
	public float speed;
    public float jetSpeed;
    new void Update() {
        base.Update();
        if (attackTarget != null){
            float step;
            if( Mathf.Abs(attackTarget.position.x - transform.position.x) < 13f){
                if ( jetAttacking == true){
                    step = jetSpeed * Time.deltaTime;
                } else {
                    step = speed * Time.deltaTime;
                }
                if((Mathf.Abs(attackTarget.position.x - transform.position.x) < 7f) && jetAttackReady){
                    animator.SetInteger("AnimState", 1);
                    jetAttackReady = false;
                    jetAttacking = true;
                } else {
                    animator.SetInteger("AnimState", 0); //Will set every frame i guess
                }
                transform.position = Vector3.MoveTowards(transform.position, attackTarget.position, step);
            }
            if (jetAttacking == true){
                jetAttackDuration -= Time.deltaTime;
                if (jetAttackDuration < 0){
                    jetAttacking = false;
                    jetAttackDuration = 0.5f;
                }
            }
            if (jetAttackReady == false) {
                jetAttackTimer -= Time.deltaTime;
                if (jetAttackTimer < 0){
                    jetAttackReady = true;
                    jetAttackTimer = 3f;
                }
            }
            if (attackTarget.position.x < transform.position.x){
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            } else {
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
        }
        if (attackTarget == null && GameHandler.instance.theDuck != null){
            attackTarget = GameHandler.instance.theDuck.transform;
        }
	}

	new void OnTriggerEnter2D(Collider2D collider){
        base.OnTriggerEnter2D(collider);
	}

    void PopulateDropTable(){
        
        //dropTable.Add();
    }
}
