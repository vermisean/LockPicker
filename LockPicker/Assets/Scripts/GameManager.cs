using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public Text skillText = null;
	public Text difficultyText = null;

	public static bool gameNotOver;
	public bool readytoLoad;

	public enum Difficulty
	{
		EASY = 0,
		MEDIUM,
		HARD
	}
	public static Difficulty difficulty;

	public static Difficulty GetDifficulty()
	{
		return difficulty;
	}

	public static int playerSkill = 1;


	void Awake () 
	{
		Cursor.visible = false;

		readytoLoad = true;
		gameNotOver = true;

		difficulty = Difficulty.EASY;

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
		if(!gameNotOver && readytoLoad)
		{
			readytoLoad = false;
			StartCoroutine ("RestartLevel");
		}
	}


	public static void GameWin(Text successText)
	{
		successText.text = "SUCCESS";
	}

	public static void GameOver(Text successText)
	{
		successText.text = "FAILURE";
	}

	public IEnumerator RestartLevel()
	{
		yield return new WaitForSeconds (5.0f);
		if(difficulty == Difficulty.EASY)
		{
			playerSkill += 1;
			if (playerSkill == 3)
				difficulty = Difficulty.MEDIUM;
			SceneManager.LoadScene ("Main");
		}
		else if(difficulty == Difficulty.MEDIUM)
		{
			playerSkill += 1;
			if (playerSkill == 5)
				difficulty = Difficulty.HARD;
			SceneManager.LoadScene ("Main");
		}
		else if(difficulty == Difficulty.HARD)
		{
			playerSkill += 3;
			SceneManager.LoadScene ("Main");
		}
	}
}
