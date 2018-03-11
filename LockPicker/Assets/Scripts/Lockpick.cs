using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpick : MonoBehaviour 
{
	public Text successText = null;
	public Slider successSlider = null;
	public float timeRequired = 15.0f;
	public float currentTime = 0.0f;

	void Start () 
	{
		successText.text = "";
		currentTime = 0.0f;
		GameManager.Difficulty difficulty = GameManager.GetDifficulty ();

		switch(difficulty)
		{
		case GameManager.Difficulty.EASY:
			timeRequired = 15.0f - GameManager.playerSkill * 5;
			break;
		case GameManager.Difficulty.MEDIUM:
			timeRequired = 20.0f - GameManager.playerSkill * 5;
			break;
		case GameManager.Difficulty.HARD:
			timeRequired = 25.0f - GameManager.playerSkill * 5;
			break;
		}

		this.GetComponent<SpriteRenderer> ().color = Color.black;
	}

	void Update () 
	{
		successSlider.value = (currentTime / timeRequired) * 100;
		MoveLockpick ();
	}

	void MoveLockpick()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "shadow" && GameManager.gameNotOver)
		{
			this.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.tag == "shadow" && GameManager.gameNotOver)
		{
			if(currentTime <= timeRequired)
			{
				currentTime += Time.fixedDeltaTime;
			}
			else
			{
				GameManager.gameNotOver = false;
				GameManager.GameWin (successText);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "shadow" && GameManager.gameNotOver)
		{
			this.GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}
}
