using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShooterBehaviour : MonoBehaviour
{

	public float attackInterval;
	float attackTimer;
	bool performAttack = false;
	public Animator animator;
	public GameObject projectile;
	public float movementSpeed;
	float posTimer;
	int projPooled = 5;
	List<GameObject> lProjectiles;


	// Use this for initialization
	void Start ()
	{
		Transform proj = GameObject.Find ("Projectiles").transform;
		lProjectiles = new List<GameObject> ();
		for (int i = 0; i < projPooled; i++) {
			GameObject obj = (GameObject)Instantiate (projectile);
			obj.transform.parent = proj;
			obj.SetActive (false);
			lProjectiles.Add (obj);

		}


		attackTimer = 0.0f;
		posTimer = 0.0f;

	}

	void OnEnable ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		AttackRoutine ();
		Movement ();

		if (transform.position.x <= -13) {
			DestroyThis ();
		}

	}

	void AttackRoutine ()
	{
		attackTimer += Time.deltaTime;
		if (attackTimer >= attackInterval) {
			animator.SetBool ("performingAttack", true);
			attackTimer = 0.0f;
		}
	}

	public void endAttack ()
	{
		animator.SetBool ("performingAttack", false);
	}

	public void spawnProjectile ()
	{
		for (int i = 0; i < lProjectiles.Count; i++) {
			if (!lProjectiles [i].activeInHierarchy) {
				lProjectiles [i].transform.position = new Vector3 (transform.position.x - 1, transform.position.y + 1, 0);
				lProjectiles [i].transform.rotation = Quaternion.identity;
				lProjectiles [i].SetActive (true);
				break;
			}
		}

	}

	void Movement ()
	{
		posTimer += Time.deltaTime;
		transform.Translate (Vector3.left * movementSpeed * Time.deltaTime);
		transform.position += 2.0f * (Mathf.Sin (2 * Mathf.PI * 0.2f * posTimer) - Mathf.Sin (2 * Mathf.PI * 0.2f * (posTimer - Time.deltaTime))) * transform.up;
	}

	void DestroyThis ()
	{
		gameObject.SetActive (false);
	}

}