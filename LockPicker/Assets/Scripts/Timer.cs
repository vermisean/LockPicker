using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public AudioSource aSource = null;
	public AudioClip failure = null;

	public Text timeText = null;
	public Text failText = null;

	private float totalTime = 60.0f;
	private bool doOnce = false;

	void Start () 
	{
		doOnce = false;

		aSource = GetComponent<AudioSource> ();
		
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
			if(!doOnce)
			{
				doOnce = true;
				aSource.PlayOneShot (failure, 1.0f);
			}

			GameManager.gameNotOver = false;
			GameManager.GameOver (failText);
		}
	}
}
