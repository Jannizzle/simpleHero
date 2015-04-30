using UnityEngine;
using System.Collections;

public class Boss2Behaviour : MonoBehaviour
{

	public GameObject projectile;
	public GameObject ripostProjectile;
	public Animator animator;
	public float movementSpeed;
	public int lives;
	public GameObject child;
	float target;
	int counter = 0;
	LevelManager cl;

	// Use this for initialization
	void Start ()
	{
		cl = (LevelManager)GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LevelManager> ();
		target = 0.0f;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.x > 5.87f) {
			transform.Translate (Vector3.left * movementSpeed * Time.deltaTime);
		} else {
			
			
			if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {

				
				if (transform.position.y != target) {
					//transform.Translate (Vector3.up * movementSpeed * Time.deltaTime);
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, target, 0.0f),
			                                          movementSpeed * Time.deltaTime);
				} else {
					StartCoroutine ("DashTo");
				}

				
						
			}
		}


		//DEBUG
		if (Input.GetKeyDown ("w")) {
			ReceiveDamage ();
		}
	}

	public void SpawnProjectile ()
	{
		Instantiate (projectile, new Vector3 (transform.position.x - 2, child.transform.position.y, transform.position.z), Quaternion.identity);
	}
	
	public void SpawnRipostProjectile ()
	{
		Instantiate (ripostProjectile, new Vector3 (transform.position.x - 3, child.transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
	}

//		public IEnumerator DashTo ()
//		{
//				Debug.Log ("Dashing");
//				float tmp = Random.Range (-4.0f, 4.0f);
//				//	yield return new WaitForSeconds (3.0f);
//				
//				target = tmp;
//				DoSomething ();
//				
//				StopCoroutine ("DashTo");
//		}

	public void DashTo ()
	{			
		float tmp = Random.Range (-4.0f, 4.0f);
		target = tmp;
		DoSomething ();
	}
	
	public void DoSomething ()
	{
				

		if (counter < 3) {
			int rnd = Random.Range (0, 4);
			switch (rnd) {
			case 0:
								
				animator.Play ("Shoot");
				counter++;
				break;
			case 1:
								
				animator.Play ("Attack");
				counter++;
				break;

			case 2:
				transform.position = new Vector3 (transform.position.x, 0.0f, 0.0f);
				rnd = Random.Range (0, 5); 
				switch (rnd) {
				case 0:
					animator.Play ("PentaShot1");
					break;
				case 1:
					animator.Play ("PentaShot2");
					break;
				case 2:
					animator.Play ("PentaShot3");
					break;
				case 3:
					animator.Play ("PentaShot4");
					break;
				case 4:
					animator.Play ("PentaShot5");
					break;
				}
				counter++;
				break;
			case 3:
				
				break;
			}
		} else {
			animator.Play ("ChargeShot");
			counter = 0;
		}
	}

	public void ReceiveDamage ()
	{
		lives--;
		Debug.Log (lives);
		if (lives == 0) {
			DestroyThis ();
		}
	}

	public void DestroyThis ()
	{
		animator.Play ("Dying");
	}

	public void DestroyItAlready ()
	{
		Destroy (gameObject);
		cl.IncrementLevel ();
	}

        

		
}
