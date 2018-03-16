using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public AudioSource aSource = null;

	public Text skillText = null;
	public Text difficultyText = null;

	public static bool gameNotOver;
	public bool readyToLoad;

	public bool click = false;

	public enum Difficulty
	{
		EASY = 0,
		MEDIUM,
		HARD
	}
	public static Difficulty difficulty = Difficulty.EASY;

	public static Difficulty GetDifficulty()
	{
		return difficulty;
	}

	public static int playerSkill = 1;


	void Awake () 
	{
		Cursor.visible = false;

		aSource = GetComponent<AudioSource> ();
		aSource.Play ();

		readyToLoad = true;
		gameNotOver = true;

		//difficulty = Difficulty.EASY;

		skillText.text = "Skill: " + playerSkill.ToString ();

		if(difficulty == Difficulty.EASY)
			difficultyText.text = difficulty.ToString ();
		else if(difficulty == Difficulty.MEDIUM)
			difficultyText.text = "MED";
		else if(difficulty == Difficulty.HARD)
			difficultyText.text = difficulty.ToString ();
	}
		
	void Update()
	{
		if(!gameNotOver && readyToLoad)
		{
			readyToLoad = false;
			StartCoroutine ("RestartLevel");
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit ();
		}
	}


	public static void GameWin(Text successText)
	{
		successText.text = "DATA ACCESSED";
	}

	public static void GameOver(Text successText)
	{
		successText.text = "SECURITY BREACH DETECTED";
	}

	public IEnumerator RestartLevel()
	{
		yield return new WaitForSeconds (5.0f);
		if(difficulty == Difficulty.EASY)
		{
			playerSkill += 1;
			if (playerSkill == 2)
				difficulty = Difficulty.MEDIUM;
			SceneManager.LoadScene ("Main");
		}
		else if(difficulty == Difficulty.MEDIUM)
		{
			playerSkill += 1;
			if (playerSkill == 4)
				difficulty = Difficulty.HARD;
			SceneManager.LoadScene ("Main");
		}
		else if(difficulty == Difficulty.HARD)
		{
			playerSkill += 2;
			SceneManager.LoadScene ("Main");
		}
	}
}
