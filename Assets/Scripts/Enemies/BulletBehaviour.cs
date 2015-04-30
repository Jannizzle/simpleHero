using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{

		public float bulletSpeed;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				transform.Translate (Vector3.left * bulletSpeed * Time.deltaTime);
		
				if (transform.position.x <= -10) {
						DestroyThis ();
				}
	
		}

		void DestroyThis ()
		{
				gameObject.SetActive (false);
		}
}
