using UnityEngine;
using System.Collections;

public class InputArea : MonoBehaviour
{

		public GameObject hero;
		MovementController move;

		// Use this for initialization
		void Start ()
		{
				bindHero ();
		}
	
		// Update is called once per frame
		void Update ()
		{

//				if (Input.GetMouseButton (0)) {
//						Debug.Log ("Input 0");
//						//hero.SendMessage ("Ascend");
//						move.Ascend ();
//				}
	
		}

		/*void OnMouseDrag ()
		{
				
				//hero.SendMessage ("Ascend");
				move.Ascend ();
		}*/

		void isTouched ()
		{
				if (Time.timeScale == 1.0f) {
						move.Ascend ();
				}
		}

		public void bindHero ()
		{
				GameObject tmp = GameObject.FindGameObjectWithTag ("Hero");
				hero = tmp;
				move = hero.GetComponent<MovementController> ();
		}
		
}
