using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public Text timeText = null;

	[SerializeField]
	private float totalTime = 60.0f;

	void Start () 
	{
		timeText.text = totalTime.ToString ();
	}
	

	void Update () 
	{
		if(totalTime > 0.0f)
		{
			totalTime -= Time.deltaTime;
			timeText.text = "Time Remaining: " + totalTime.ToString ("N0");
		}

		if(totalTime <= 0.0f)
		{
			GameManager.GameOver ();
		}
	}
}
