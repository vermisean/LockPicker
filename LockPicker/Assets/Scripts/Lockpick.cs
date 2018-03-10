using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpick : MonoBehaviour 
{


	void Start () 
	{
		
	}
	

	void Update () 
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}

	void MoveLockpick()
	{
		
	}

}
