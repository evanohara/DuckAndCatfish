using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckButtController : MonoBehaviour {

    public GameObject theDuck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            theDuck.GetComponent<DuckController>().BounceUp();
    }
}
