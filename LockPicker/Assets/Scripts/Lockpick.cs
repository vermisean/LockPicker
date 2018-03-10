using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpick : MonoBehaviour 
{
	public Transform lockpickTransform;

	[SerializeField]
	private float speed;

	private Vector3 viewPortActual; 
	private Vector3 viewPortDelta;
	private Vector3 directionToMouse;


	void Start () 
	{
		
	}
	

	void Update () 
	{
		MoveLockpick ();
	}

	void MoveLockpick()
	{
		lockpickTransform.LookAt(new Vector3(0.0f, 
			lockpickTransform.position.x + GetNormalizedDirectionToMouse().x,
			0.0f));
	}

	public Vector3 GetNormalizedDirectionToMouse()
	{
		// Calculate a direction based on the Mouse Position (using Viewport)
		viewPortActual = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		viewPortDelta = new Vector3(0.5f, 0.5f, 0); // Detract Half the screen
		directionToMouse = viewPortActual - viewPortDelta; // Caculate Direction
		return directionToMouse.normalized; // Return normalized Direction
	}
}
