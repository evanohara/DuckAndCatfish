using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {
	public static GameHandler instance = null;
	public GameObject theDuck;
	public GameObject theCatfish;

	public int duckLives = 3;
	public int catfishLives = 3;

	public List<GameObject> miniDucks;
	public List<GameObject> miniCatfish;

	void Awake ()
    {
            //Check if there is already an instance of SoundManager
            if (instance == null)
                //if not, set it to this.
                instance = this;
            //If instance already exists:
            else if (instance != this)
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy (gameObject);
            
            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad (gameObject);
    }

	public void DuckGotHit(){
		if (duckLives > 0)
		{
			duckLives--;
			GameObject lastDuck = miniDucks[duckLives];
			miniDucks.Remove(lastDuck);
			Destroy(lastDuck);
		} else {
			Destroy(theDuck);
		}
	}

	public void CatfishGotHit(){
		if (catfishLives > 0)
		{
			catfishLives--;
			GameObject lastCatfish = miniCatfish[catfishLives];
			miniDucks.Remove(lastCatfish);
			Destroy(lastCatfish);
		} else {
			Destroy(theCatfish);
		}
	}

		
	
	// Update is called once per frame
	void Update () {
		
	}
}
