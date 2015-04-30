using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour
{

		public float scrollSpeed = 0;
		

		// Update is called once per frame
		void Update ()
		{
				
				GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Time.time * scrollSpeed, 0f);
				
		}

}
