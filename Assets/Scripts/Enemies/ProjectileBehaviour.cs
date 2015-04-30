using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileBehaviour : MonoBehaviour
{

	public float projectileSpeed;
		
	void Start ()
	{

			
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.left * projectileSpeed * Time.deltaTime);

		if (transform.position.x <= -13) {
			DestroyThis ();
		}
	}

	void DestroyThis ()
	{
		gameObject.SetActive (false);
	}

	public void setProjSpeed (float amount)
	{
		projectileSpeed = amount;

	}

}
