using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpick : MonoBehaviour 
{
	public AudioSource aSource = null;
	public AudioClip success = null;

	public Text successText = null;
	public Slider successSlider = null;
	public float timeRequired = 15.0f;
	public float currentTime = 0.0f;

	private bool OnTarget = false;
	private bool doOnce = false;

	void Start () 
	{
		aSource = GetComponent<AudioSource> ();

		doOnce = false;

		successText.text = "";
		currentTime = 0.0f;
		GameManager.Difficulty difficulty = GameManager.GetDifficulty ();

		switch(difficulty)
		{
		case GameManager.Difficulty.EASY:
			timeRequired = 15.0f - GameManager.playerSkill * 1.5f;
			break;
		case GameManager.Difficulty.MEDIUM:
			timeRequired = 20.0f - GameManager.playerSkill * 1.5f;
			break;
		case GameManager.Difficulty.HARD:
			timeRequired = 25.0f - GameManager.playerSkill * 1.5f;
			break;
		}

		this.GetComponent<SpriteRenderer> ().color = Color.red;
	}

	void Update () 
	{
		successSlider.value = (currentTime / timeRequired) * 100;
		MoveLockpick ();

		if(currentTime <= timeRequired && currentTime > 0.0f && !OnTarget)
		{
			currentTime -= Time.fixedDeltaTime / 2.0f;
		}
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
			this.GetComponent<SpriteRenderer> ().color = Color.green;
		}
		OnTarget = true;
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
				if(!doOnce)
				{
					doOnce = true;
					aSource.PlayOneShot (success, 1.0f);
				}
				GameManager.gameNotOver = false;
				GameManager.GameWin (successText);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "shadow" && GameManager.gameNotOver)
		{
			this.GetComponent<SpriteRenderer> ().color = Color.red;
		}

		OnTarget = false;
	}
}
