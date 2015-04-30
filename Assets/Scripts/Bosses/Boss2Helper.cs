using UnityEngine;
using System.Collections;

public class Boss2Helper : MonoBehaviour
{

		Boss2Behaviour parentObject;

		// Use this for initialization
		void Start ()
		{
				parentObject = this.gameObject.GetComponentInParent<Boss2Behaviour> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void setState (int state)
		{
				
		}

		void SpawnProjectile ()
		{
				parentObject.SpawnProjectile ();
		}
	
		void SpawnRipostProjectile ()
		{
				parentObject.SpawnRipostProjectile ();
		}

		void DashTo ()
		{
				parentObject.StartCoroutine ("DashTo");
		}

		public void ReceiveDamage ()
		{
				parentObject.ReceiveDamage ();
		}

		public void DestroyItAlready ()
		{
				parentObject.DestroyItAlready ();
		}

		
}
