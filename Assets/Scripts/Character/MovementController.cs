﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{

	Vector2 correction;
	public float ascendingV;
	public GameObject touchArea;
	InputArea inputArea;
	public GameObject button;
	Button inputButton;
	bool performingAttack;
	Animator animator;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
	{
		GameObject tmp = GameObject.FindGameObjectWithTag ("InputArea");
		touchArea = tmp;
		inputArea = touchArea.GetComponent<InputArea> ();
		inputArea.bindHero ();

		GameObject tmp2 = GameObject.FindGameObjectWithTag ("Button");
		button = tmp2;
		inputButton = button.GetComponent<Button> ();
		inputButton.bindHero ();

		animator = gameObject.GetComponentInChildren<Animator> ();
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();

	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKey ("p") && !StateManager.gamePaused) {
			Ascend ();
		}
	}

	void Update ()
	{

		if (transform.position.x <= -4) {
			correctPosition ();
		}

		if (Input.GetKeyDown ("s") && !StateManager.gamePaused) {
			Attack ();
		}



	}

	void correctPosition ()
	{
		correction.x = -4 - transform.position.x;
		transform.Translate (correction * Time.deltaTime);
	}

	public void Ascend ()
	{

		gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * ascendingV);
        
	}

	public void KnockBack ()
	{
		rigidBody.velocity = rigidBody.velocity * -0.7f;
	}

	public void Attack ()
	{
		performingAttack = true;
		animator.SetBool ("performingAttack", true);
	}

	public void endAttack ()
	{
		performingAttack = false;
		animator.SetBool ("performingAttack", false);
	}
}
