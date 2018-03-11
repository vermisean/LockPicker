using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public Text timeText = null;
	public Text failText = null;

	private float totalTime = 60.0f;


	void Start () 
	{
		failText.text = "";

		GameManager.Difficulty difficulty = GameManager.GetDifficulty ();

		switch(difficulty)
		{
		case GameManager.Difficulty.EASY:
			totalTime = 40.0f + GameManager.playerSkill * 5;
			break;
		case GameManager.Difficulty.MEDIUM:
			totalTime = 30.0f + GameManager.playerSkill * 5;
			break;
		case GameManager.Difficulty.HARD:
			totalTime = 20.0f + GameManager.playerSkill * 5;
			break;
		}

		timeText.text = totalTime.ToString ();
	}
	

	void Update () 
	{

		if(totalTime > 0.0f && GameManager.gameNotOver)
		{
			totalTime -= Time.deltaTime;
			timeText.text = "Time: " + totalTime.ToString ("N0");
		}

		if(totalTime <= 0.0f)
		{
			GameManager.gameNotOver = false;
			GameManager.GameOver (failText);
		}
	}
}
