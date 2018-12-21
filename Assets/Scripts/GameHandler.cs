using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {
	public static GameHandler instance = null;
	public GameObject theDuck;
	public GameObject theCatfish;
	public GameObject theBoss;

	public GameObject canvas;

	public int duckLives = 0;
	public int catfishLives = 0;

	private List<Image> miniDucks;
	private List<Image> miniCatfish;
	public GameObject gameOverText;
	public GameObject gameWinText;

	public Image catfishLifePrefab;
	public Image duckLifePrefab;
	public Image duckActiveWeapon;
	public Sprite duckBloopSprite;
	public Sprite duckGustSprite;

	private bool endingSequence;

	private bool isPaused;



	private float endingTimer;

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
            //DontDestroyOnLoad (gameObject);
    }

	void Start(){
		endingSequence = false;
		endingTimer = 2f;
		miniDucks = new List<Image>();
		miniCatfish = new List<Image>();
		CatfishLifeUp();
		CatfishLifeUp();
		CatfishLifeUp();
		DuckLifeUp();
		DuckLifeUp();
		DuckLifeUp();
		isPaused = false;
	}

	public bool IsPaused(){
		return isPaused;
	}

	public void DuckGotHit(){
		if (duckLives > 0)
		{
			duckLives--;
			Image lastDuck = miniDucks[duckLives];
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
			Image lastCatfish = miniCatfish[catfishLives];
			miniCatfish.Remove(lastCatfish);
			Destroy(lastCatfish);
		} else {
			Destroy(theCatfish);
		}
	}

	public void CatfishLifeUp(){
		Image newCatfishLife = Instantiate (catfishLifePrefab, canvas.transform);
		miniCatfish.Add(newCatfishLife);
		newCatfishLife.transform.position = 
			new Vector2(newCatfishLife.transform.position.x - miniCatfish.Count * 25f - 25f,
				newCatfishLife.transform.position.y);
		catfishLives++;

	}

	public void DuckLifeUp(){
		Image newDuckLife = Instantiate (duckLifePrefab, canvas.transform);
		miniDucks.Add(newDuckLife);
		newDuckLife.transform.position = 
			new Vector2(newDuckLife.transform.position.x + miniDucks.Count * 25f + 25f,
				newDuckLife.transform.position.y);
		duckLives++;
	}

	public void SetDuckWeapon( DuckController.DuckWeapons weapon){
		if (weapon == DuckController.DuckWeapons.Bloop){
			duckActiveWeapon.sprite = duckBloopSprite;
		} else if (weapon == DuckController.DuckWeapons.Gust){
			duckActiveWeapon.sprite = duckGustSprite;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause")){
			if (Time.timeScale < 0.9f){
				ResumeGame();
				isPaused = false;
			} else {
				PauseGame();
				isPaused = true;
			}

		}
		if (endingSequence == false){
			if ((theCatfish == null) && (theDuck == null)){
				StartEndingSequence();
			} else if (theBoss == null){
				StartWinningSequence();
			}
		} else {
			endingTimer -= Time.deltaTime;
			if (endingTimer < 0){
				endingTimer = 2f;
				endingSequence = false;
				if ((theCatfish == null) && (theDuck == null)){
					SceneManager.LoadScene("Menu");
				} else {
					SceneManager.LoadScene("LevelTwo");
				}
			}
		}
	}

	public void StartEndingSequence(){
		gameOverText.SetActive(true);
		endingSequence = true;
	}
	public void StartWinningSequence(){
		gameWinText.SetActive(true);
		endingSequence = true;
	}

	public void PauseGame(){
		Time.timeScale = 0;
		AudioManager.instance.PauseMusic();
		AudioManager.instance.PlayPauseSound();
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		AudioManager.instance.ResumeMusic();
		AudioManager.instance.PlayPauseSound();
	}
}
