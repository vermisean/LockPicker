using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpick : MonoBehaviour 
{
	public float minRotation = 0.0f;
	public float maxRotation = 180.0f;
	public float currentRotation = 1.0f;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		Debug.Log (Input.mousePosition);
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

/*		if(Input.mousePosition.y >= 650.0f)
		{
			if(this.transform.rotation.z < 0.0f)
			{
				this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, minRotation);
				//this.transform.rotation.z = minRotation;
			}
			else if(this.transform.rotation.z > 180.0f)
			{
				this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, maxRotation);
				//this.transform.rotation.z = maxRotation;
			}
			else if(this.transform.rotation.z >= 0.0f && this.transform.rotation.z <= 180.0f)
			{
				this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
		}*/

	}

	void MoveLockpick()
	{
		
	}

}
