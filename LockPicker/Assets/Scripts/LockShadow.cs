using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockShadow : MonoBehaviour 
{
	public AudioSource aSource = null;
	public AudioClip beep = null;

	public GameManager gameManager;

	private bool canChangeDirection;
	private bool canRotate;
	private float changeTime;
	private float spinSpeed = 0.25f;
	private float coolDownTimer = 0.0f;


	void Start () 
	{
		aSource = GetComponent<AudioSource> ();
		canRotate = true;
		gameManager = FindObjectOfType<GameManager> ();

		GameManager.Difficulty difficulty = GameManager.GetDifficulty ();

		switch(difficulty)
		{
		case GameManager.Difficulty.EASY:
			canChangeDirection = false;
			spinSpeed = 0.35f - GameManager.playerSkill / 10;
			break;
		case GameManager.Difficulty.MEDIUM:
			canChangeDirection = true;
			changeTime = Random.Range (5.0f, 10.0f);
			spinSpeed = 0.9f - GameManager.playerSkill / 10;
			break;
		case GameManager.Difficulty.HARD:
			canChangeDirection = true;
			changeTime = Random.Range (1.0f, 10.0f);
			spinSpeed = 1.3f - GameManager.playerSkill / 10;
			break;
		}
	}
	

	void Update () 
	{
		Spin ();
	}

	void Spin()
	{
		canRotate = GameManager.gameNotOver;
		if(canRotate)
		{
			Vector3 euler = this.transform.eulerAngles;

			if(canChangeDirection)
			{
				coolDownTimer += Time.fixedDeltaTime;

				if(coolDownTimer >= changeTime)
				{
					aSource.PlayOneShot (beep, 1.0f);

					if(GameManager.difficulty == GameManager.Difficulty.MEDIUM)
					{
						changeTime = Random.Range (5.0f, 10.0f);
					}
					else if(GameManager.difficulty == GameManager.Difficulty.HARD)
					{
						changeTime = Random.Range (1.0f, 10.0f);
					}
					coolDownTimer = 0.0f;
					spinSpeed *= -1.0f;
				}
				else if(coolDownTimer < changeTime)
				{
					euler.z += spinSpeed;
				}
			}
			else
			{
				euler.z += spinSpeed;
			}

			this.transform.eulerAngles = euler;
		}
	}
}
