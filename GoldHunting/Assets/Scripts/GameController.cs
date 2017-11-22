﻿/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: REVISION 5 TIMES
 * CODE REFFERENCE: LAB 6
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Update interface
public class GameController : MonoBehaviour {

	[SerializeField] Text lifeLabel = null;
	[SerializeField] Text scoreLabel = null;
	[SerializeField] Text highScoreLable = null;
	[SerializeField] Text gameOverLabel = null;
	[SerializeField] Text winLabel = null;
	[SerializeField] Button startBtn = null;
	[SerializeField] Button resetBtn = null;
	[SerializeField] GameObject ghost = null;
	[SerializeField] GameObject coin = null;
	[SerializeField] GameObject bulletbox = null;


	void Start () {
		// connect Player class to this class
		Player.Instance.gameCtrl = this;
		StartGame ();
//		initialize ();
	}

	// start the game
	public void StartGame(){
		
		startBtn.gameObject.SetActive (true);

		// disable the ghost/coin/bulletbox
		ghost.gameObject.SetActive(false);
		coin.gameObject.SetActive(false);
		bulletbox.gameObject.SetActive(false);

		// hide life/score/gameover/win/highscore labels and restart button
		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		gameOverLabel.gameObject.SetActive (false);
		winLabel.gameObject.SetActive(false);
		highScoreLable.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);
	}

	// restart playing mode
	// initialize the starts
	private void initialize(){

		// call the Player class functions disaplay the current score and lives to the user
		Player.Instance.Point = 0;
		Player.Instance.Life = 3;
//		Player.Instance.HighScore = 0;

		// disable the ghost/coin/bulletbox
		ghost.gameObject.SetActive(true);
		coin.gameObject.SetActive(true);
		bulletbox.gameObject.SetActive(true);

		// enable life/score label
		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);

		// hide the start button/gameover/win/highscore/reset button
		startBtn.gameObject.SetActive (false);
		gameOverLabel.gameObject.SetActive (false);
		winLabel.gameObject.SetActive(false);
		highScoreLable.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);

		// create more ghost to increase the challange to the user
		StartCoroutine ("MoreGhost");
	}

	// appear the result when the life == 0
	public void GameOver(){
		
		// display game over hightscore and restart labels
		gameOverLabel.gameObject.SetActive (true);
		highScoreLable.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		// disable the ghost/coin/bulletbox


		// life and score not appear
		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		winLabel.gameObject.SetActive(false);
		startBtn.gameObject.SetActive (false);
		highScoreLable.text = "Your Score: " + Player.Instance.Point;

	}

	// appear the result when collected 1000 points
	// or collected the golden crown
	public void Win(){
		
		// display win / score / restart labels
		winLabel.gameObject.SetActive(true);
		highScoreLable.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		// disable the ghost/coin/bulletbox
		ghost.gameObject.SetActive(false);
		coin.gameObject.SetActive(false);
		bulletbox.gameObject.SetActive(false);

		// not display the life score and gameover labels
		scoreLabel.gameObject.SetActive(false);
		lifeLabel.gameObject.SetActive(false);
		gameOverLabel.gameObject.SetActive(false);
		startBtn.gameObject.SetActive (false);
		highScoreLable.text = "Your Score: " + Player.Instance.Point;
	}

	// restart button function
	public void StartBtnClick(){
		//hide the start button
//		startBtn.gameObject.SetActive (false);
		// start the game
		initialize ();
	}

	// restart button function
	public void ResetBtnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		initialize ();
	}

	// create more ghosts to the scene to challange the user
	private IEnumerator MoreGhost(){

		int time = Random.Range(1,10);
		yield return new WaitForSeconds ((float)time);
		Instantiate (ghost);

		// increase the challange to the user
//		StartCoroutine ("MoreGhost");
	}

	// call Player class to get score and life information to the UI
	public void updateUI(){
		scoreLabel.text = "Score: " + Player.Instance.Point;
		lifeLabel.text = "Life: " + Player.Instance.Life;
		highScoreLable.text = "Your Score: " + Player.Instance.Point;
	}
}
