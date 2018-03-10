using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public enum Difficulty
	{
		EASY = 0,
		MEDIUM,
		HARD
	}

	public int playerSkill = 0;


	void Start () 
	{
		Cursor.visible = false;
	}
	

	void Update () 
	{
		
	}

	public static void GameOver()
	{
		Debug.Log ("GAME OVER");
	}
}
