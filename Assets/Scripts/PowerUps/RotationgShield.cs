using UnityEngine;
using System.Collections;

public class RotationgShield : MonoBehaviour
{

		public float factor;
		

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.Rotate (0, 0, factor);
		}
}
