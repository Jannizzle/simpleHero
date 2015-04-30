using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
		
//				if (GUI.Button (new Rect (Screen.width / 2, 50, 100, 40), "Level1")) {
//						Application.LoadLevel ("Level1");
//				}
//
//				if (GUI.Button (new Rect (Screen.width / 2, 100, 100, 40), "Loop")) {
//						//Application.LoadLevel("Loop");
//				}
//
//				if (GUI.Button (new Rect (Screen.width / 2, 150, 100, 40), "BossFight")) {
//						//Application.LoadLevel("Boss");
//				}
		

		}

		public void LoadLevel ()
		{
				Application.LoadLevel ("Level1");
		}
}
