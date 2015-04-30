using UnityEngine;
using System.Collections;

public class Boss3Behaviour : MonoBehaviour
{

	public Animator animator;
	int aSelector;
	public EffectBox eb;
	public LevelManager cl;
	public TestSceneLogic tl;
	public GameObject flame;
	public GameObject fireBall;
	public GameObject splittingShot;
	Vector2 originPos;
	public int sweatCounter;
	bool inSweatPhase;
	public int sweatPhaseDuration;

	//DoubleShot positions
	public Vector2 pos1;
	public Vector2 pos2;
	public Vector2 pos3;
	int blinkCounter;
	int blinksTillAttack;
	int frameCounter;
	public int coolDown;
	bool inRoutine;
	int attacksPerformed;

	//Illusions
	public GameObject illusion;
	Boss3Helper child;
	GameObject copy1;
	GameObject copy2;
	public int lives;
	public GameObject villainIllusion;



	// Use this for initialization
	void Start ()
	{
		GameObject tmp = GameObject.FindGameObjectWithTag ("MainCamera");
		eb = tmp.GetComponent<EffectBox> ();
		cl = tmp.GetComponent<LevelManager> ();
		tl = tmp.GetComponent<TestSceneLogic> ();
		blinkCounter = 0;
		inRoutine = false;
		attacksPerformed = 0;
		blinksTillAttack = 0;
		child = gameObject.GetComponentInChildren<Boss3Helper> ();

	}

	// Update is called once per frame
	void Update ()
	{
		if (inSweatPhase) {
			sweatCounter++;
			if (sweatCounter >= sweatPhaseDuration) {
				transform.position = originPos;
				Destroy (copy1);
				Destroy (copy2);
				inSweatPhase = false;
				sweatCounter = 0;
				attacksPerformed = 0;
				frameCounter = 0;
			}
		} else {
			if (!inRoutine) {
				frameCounter++;
				if (frameCounter == coolDown) {
					if (blinkCounter < blinksTillAttack) {
						animator.Play ("Blinking");
						blinkCounter++;
						frameCounter = 0;
					} else {
						DoSomething ();
					}
				}
			}
		}

		//if (Input.GetKeyDown("j"))
		//{
		//    DoSomething();
		//}

		//if (Input.GetKeyDown("n"))
		//{
		//    animator.Play("Blinking");
		//}

		//DEBUG
		if (Input.GetKeyDown ("w")) {
			ReceiveDamage ();
		}

	}

	public void DoSomething ()
	{
		if (attacksPerformed == 3) {
			animator.Play ("SweatBlink");
			//ChoosePattern();
		} else {
			animator.Play ("Attacking");
			aSelector = Random.Range (0, 4);
		}
	}

	public void ChooseEffect ()
	{
		switch (aSelector) {
		case 0:

			flame.SetActive (true);
			flame.SendMessage ("setVertigo");
			break;
		case 1:

			flame.SetActive (true);
			flame.SendMessage ("setSummon");
			break;
		case 2:

			flame.SetActive (true);
			flame.SendMessage ("setDoubleShot");
			break;
		case 3:

			flame.SetActive (true);
			flame.SendMessage ("setSplittingShot");
			break;
		}
	}

	public void PerformAttack ()
	{

		switch (aSelector) {
		case 0:
			eb.Vertigo ();
			flame.SetActive (false);
			break;
		case 1:

			Instantiate (villainIllusion, new Vector2 (transform.position.x - 2.0f, transform.position.y), Quaternion.identity);
			flame.SetActive (false);
			break;
		case 2:
			CastFireball ();
			flame.SetActive (false);
			break;

		case 3:
			Instantiate (splittingShot, new Vector2 (5.0f, transform.position.y), Quaternion.identity);
			flame.SetActive (false);
			break;
		}
		frameCounter = 0;
		blinkCounter = 0;
		blinksTillAttack = Random.Range (1, 4);
		attacksPerformed++;
		inRoutine = false;


	}

	public void CastFireball ()
	{
		int rnd = Random.Range (0, 3);
		switch (rnd) {
		case 0:
			Instantiate (fireBall, pos1, Quaternion.identity);
			Instantiate (fireBall, pos2, Quaternion.identity);
			break;
		case 1:
			Instantiate (fireBall, pos1, Quaternion.identity);
			Instantiate (fireBall, pos3, Quaternion.identity);
			break;
		case 2:
			Instantiate (fireBall, pos2, Quaternion.identity);
			Instantiate (fireBall, pos3, Quaternion.identity);
			break;
		}
	}

	public void Blink ()
	{
		float rnd = Random.Range (-4, 4);
		transform.position = new Vector2 (transform.position.x, rnd);
	}

	public void ChoosePattern ()
	{
		originPos = transform.position;
		int rnd = Random.Range (0, 3);
		copy1 = Instantiate (illusion, new Vector2 (-1, +3), Quaternion.identity) as GameObject;
		copy2 = Instantiate (illusion, new Vector2 (-1, -3), Quaternion.identity) as GameObject;
		gameObject.SetActive (false);
		inSweatPhase = true;
		switch (rnd) {
		case 0:
			transform.position = new Vector2 (-1.5f, 0);
			copy1.transform.position = new Vector2 (transform.position.x, transform.position.y + 3);
			copy2.transform.position = new Vector2 (transform.position.x, transform.position.y - 3);
			copy1.SetActive (true);
			copy2.SetActive (true);
			gameObject.SetActive (true);
			break;
		case 1:
			transform.position = new Vector2 (-1.5f, 3);
			copy1.transform.position = new Vector2 (transform.position.x, transform.position.y - 6);
			copy2.transform.position = new Vector2 (transform.position.x, transform.position.y - 3);
			copy1.SetActive (true);
			copy2.SetActive (true);
			gameObject.SetActive (true);


			break;
		case 2:
			transform.position = new Vector2 (-1.5f, -3);
			copy1.transform.position = new Vector2 (transform.position.x, transform.position.y + 3);
			copy2.transform.position = new Vector2 (transform.position.x, transform.position.y + 6);
			copy1.SetActive (true);
			copy2.SetActive (true);
			gameObject.SetActive (true);

			break;
		}
	}

	public void ReceiveDamage ()
	{
		sweatCounter = sweatPhaseDuration;
		lives--;
		if (lives == 0) {
			animator.Play ("Dying");
		}
	}

	public void DieAlready ()
	{
		Destroy (gameObject);
	}




}
