using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SniperBehaviour : MonoBehaviour
{

	public float lockHeight;
	public float movementSpeed;
	public float projSpeed;
	public int waitingTime;
	int framecount;
	int waitcounter;
	int shotCounter;
	float target;
	bool moving;
	int timesMoved;
	List<GameObject> lProjectiles;
	int projPooled;
	public GameObject projectile;


	// Use this for initialization
	void Start ()
	{
		shotCounter = 0;
		waitcounter = 0;
		timesMoved = 0;
		target = Random.Range (-4.0f, 4.0f);
		projPooled = 12;


		Transform proj = GameObject.Find ("Projectiles").transform;
		lProjectiles = new List<GameObject> ();
		for (int i = 0; i < projPooled; i++) {
			GameObject obj = (GameObject)Instantiate (projectile);
			obj.transform.parent = proj;
			obj.SendMessage ("setProjSpeed", projSpeed);
			obj.SetActive (false);
			lProjectiles.Add (obj);

		}

	}

	void OnEnable ()
	{   
		shotCounter = 0;
		waitcounter = 0;
		timesMoved = 0;
		target = Random.Range (-4.0f, 4.0f);
	} 
	
	// Update is called once per frame
	void Update ()
	{
		waitcounter++;

		if (transform.position.x > lockHeight) {
			
			transform.Translate (Vector3.left * movementSpeed * Time.deltaTime);
		} else if (waitcounter > waitingTime) {
			if (transform.position.y != target) {
				//transform.Translate (Vector3.up * movementSpeed * Time.deltaTime);
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, target, 0.0f),
				                                          movementSpeed * Time.deltaTime);
			} else if (timesMoved == 2) {
				shotCounter++;
				tripleShot ();
			} else {
				timesMoved++;
				target = Random.Range (-3.5f, 3.5f);
				waitcounter = 0;
			}
		}
	
	}

	public void spawnProjectile ()
	{
		for (int i = 0; i < lProjectiles.Count; i++) {
			if (!lProjectiles [i].activeInHierarchy) {
				lProjectiles [i].transform.position = new Vector3 (transform.position.x - 1.5f, transform.position.y, 0);
				lProjectiles [i].transform.rotation = Quaternion.identity;
				lProjectiles [i].SetActive (true);
				break;
			}
		}
		
	}

	void tripleShot ()
	{
		if (shotCounter == 10) {
			spawnProjectile ();
		}
		if (shotCounter == 20) {
			spawnProjectile ();
		}
		if (shotCounter == 30) {
			spawnProjectile ();
		}
		if (shotCounter > 40) {
			transform.Translate (Vector3.right * movementSpeed * Time.deltaTime);
		}
		if (shotCounter == 50) {
			gameObject.SetActive (false);
		}
	}

}
