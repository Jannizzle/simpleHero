using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour
{

	public float bossSpeed = 1.0f;
	int movement = 0; // 0 is down, 1 is up, 2 is idle
	int rnd;
	public Animator animator;
	public int bossLives;
	LevelManager cl;
		
	// Use this for initialization
	void Start ()
	{
		cl = (LevelManager)GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LevelManager> ();
		movement = 0;
		bossLives = 3;
				
	}

		
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.x > 4.0f) {
			transform.Translate (Vector3.left * bossSpeed * Time.deltaTime);
		} else {

			switch (movement) {
			case 0:
				transform.Translate (Vector3.down * bossSpeed * Time.deltaTime);
				break;
			case 1:
				transform.Translate (Vector3.up * bossSpeed * Time.deltaTime);
				break;
			case 2:
				break;
			}

			if (transform.position.y >= 2.4f) {
				rnd = Random.Range (0, 3);
				switch (rnd) {
				case 0:
					movement = 0;
					break;
				case 1:
					movement = 0;
					break;
				case 2:
					transform.position = new Vector2 (transform.position.x, transform.position.y - 0.4f);
					pattern ();
					break;
				}
			}

			if (transform.position.y <= -2.4f) {
				rnd = Random.Range (1, 3);
				;
				switch (rnd) {
				case 0:
					movement = 1;
					break;
				case 1:
					movement = 1;
					break;
				case 2:
					transform.position = new Vector2 (transform.position.x, transform.position.y + 0.4f);
					pattern ();
					break;
				}
			}
						
				

		}

		//DEBUG
		if (Input.GetKeyDown ("w")) {
			ReceiveDamage ();
		}
				
	
	}

	public void pattern ()
	{
		movement = 2;
		rnd = Random.Range (0, 2);
				
		switch (rnd) {
		case 0:
			animator.SetBool ("BossArm", true);
			break;
		case 1:
			animator.SetBool ("BossBlade", true);
			break;
		}
				
	}

	public void setBossBlade (bool mode)
	{
		animator.SetBool ("BossBlade", mode);
	

			
	}

	public void setBossArm (bool mode)
	{
		animator.SetBool ("BossArm", mode);
		
	}

	public void setBossSweet (bool mode)
	{
		animator.SetBool ("BossSweet", mode);
				
				
		
	}
	
	public void goOn ()
	{
				
		if (transform.position.y < 0) {
			movement = 1;
		} else {
			movement = 0;
		}
	}

	void ReceiveDamage ()
	{
		bossLives--;
		if (bossLives == 0) {
			//DestroyThis ();
			if (Application.loadedLevelName == "Level1") {
				cl.IncrementLevel ();
			}
			Destroy (this.gameObject);
		}
	}

	void DestroyThis ()
	{
		Destroy (gameObject);

				
	}
	

}
