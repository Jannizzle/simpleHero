using UnityEngine;
using System.Collections;

public class GuardianBehaviour : MonoBehaviour
{

		public float guardianSpeed;
		int routineState;
		public Animator animator;
		bool inRoutine = false;

		// Use this for initialization
		void Start ()
		{
				inRoutine = false;
		}

		void onEnable ()
		{
				animator.Play ("Guardian_Idle");
				setState (0);
				inRoutine = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				

				if (transform.position.x <= -2 && !inRoutine) {
						
						Routine ();
						
				}
					
				if (!inRoutine) {
						transform.Translate (Vector3.left * guardianSpeed * Time.deltaTime);
				}

				
	
		}

		public void Routine ()
		{
				inRoutine = true;
				setState (1);
				//animator.SetInteger ("RoutineState", 1);

		}

		public void setState (int state)
		{
				routineState = state;
				animator.SetInteger ("RoutineState", state);
				//Debug.Log (state);
				//Debug.Log (animator.GetInteger ("RoutineState"));
		}

		public void DestroyThis ()
		{
				inRoutine = false;
				
				
				gameObject.SetActive (false);
		}

		public int getState ()
		{
				return routineState;
		}
}
