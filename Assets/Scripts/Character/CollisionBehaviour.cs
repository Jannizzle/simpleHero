using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionBehaviour : MonoBehaviour
{

	//Damage Values
	public int bulletDmg = DamageValues.bulletDmg;
	public int villainDmg = DamageValues.villainDmg;
	public int shooterDmg = DamageValues.shooterDmg;
	public int guardianDmg = DamageValues.guardianDmg;
	public int mimeDmg = DamageValues.mimeDmg;
	public int aimerDmg = DamageValues.aimerDmg;
	public int shadowDmg = DamageValues.shadowDmg;
	public AudioClip powSound;
	GameObject[] gameObjects;
	public GameObject[] PopUps;
	List<GameObject> lPopUps;
	int pAmountPopUps = 16;
	bool performingAttack;
	Material mat;
	public Color defaultColor;
	public Color damageReceived;
	public Color invincibleColor;
	bool recovering = false;
    

	//Score
	ScoreTracking scoreTracking;
	Animator animator;
	//Hero
	HeroManager hero;
	MovementController movement;
	//SFX
	SoundManager sfx;

	// Use this for initialization
	void Start ()
	{
		GameObject tmp = GameObject.FindGameObjectWithTag ("MainCamera");
		scoreTracking = tmp.GetComponent<ScoreTracking> ();
		hero = GameObject.FindGameObjectWithTag ("Hero").GetComponent<HeroManager> ();
		movement = GameObject.FindGameObjectWithTag ("Hero").GetComponent<MovementController> ();
		mat = gameObject.GetComponent<Renderer> ().material;
		sfx = tmp.GetComponentInChildren<SoundManager> ();
		animator = gameObject.GetComponentInChildren<Animator> ();


		//Pop-Ups
		lPopUps = new List<GameObject> ();
		Transform popUps = GameObject.Find ("PopUps").transform;
		for (int i = 0; i < PopUps.Length; i++) {
			GameObject obj = (GameObject)Instantiate (PopUps [i]);
			obj.transform.parent = popUps;
			GameObject obj2 = (GameObject)Instantiate (PopUps [i]);
			obj2.transform.parent = popUps;
			GameObject obj3 = (GameObject)Instantiate (PopUps [i]);
			obj3.transform.parent = popUps;
			GameObject obj4 = (GameObject)Instantiate (PopUps [i]);
			obj4.transform.parent = popUps;
			obj.SetActive (false);
			obj2.SetActive (false);
			obj3.SetActive (false);
			obj4.SetActive (false);
			lPopUps.Add (obj);
			lPopUps.Add (obj2);
			lPopUps.Add (obj3);
			lPopUps.Add (obj4);
		}

	}

	public void receiveDamage (int dmg, bool instaDeath, bool recovery)
	{
		scoreTracking.resetMultiplier ();

		if (instaDeath) {
			hero.receiveDamage (dmg);
			CheckDeath ();
		} else if (!HeroManager.invincible && !recovering) {
			hero.receiveDamage (dmg);
			CheckDeath ();
			if (hero.getHp () >= 1 && recovery) {
				StartCoroutine ("recoveryRoutine");
			}
            
		}
	}

	void AddHealth (int amount)
	{
		hero.AddHealth (amount);
	}

	void KillHeal ()
	{
		hero.AddHealth (1);
	}

	void KillEnemy (Collider2D other)
	{
		other.SendMessage ("DestroyThis", SendMessageOptions.DontRequireReceiver);
		scoreTracking.AddScore (100.0f);
		scoreTracking.riseMultiplier ();
		scoreTracking.incrementKillCount ();
		sfx.PlayKillSound ();
		SpawnPopUp (lPopUps);
		KillHeal ();
	}

	void KillEnemyParent ()
	{
		scoreTracking.AddScore (100.0f);
		scoreTracking.riseMultiplier ();
		scoreTracking.incrementKillCount ();
		sfx.PlayKillSound ();
		SpawnPopUp (lPopUps);
		KillHeal ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Villain" || other.gameObject.tag == "Shooter" || other.gameObject.tag == "Shadow") {

			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
				KillEnemy (other);
			} else if (!HeroManager.invincible && !recovering) {
				other.SendMessage ("DestroyThis", SendMessageOptions.DontRequireReceiver);
				receiveDamage (villainDmg, false, true);

			}

		}

		if (other.gameObject.tag == "Mime") {
			
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
				MimeBehaviour m = other.GetComponentInParent<MimeBehaviour> ();
				m.DestroyThis ();
				KillEnemyParent ();
			} else if (!HeroManager.invincible && !recovering) {
				receiveDamage (mimeDmg, false, true);
				
			}
		}

		if (other.gameObject.tag == "Guardian") {
			//Debug.Log ("Guardian Hit");
			GuardianBehaviour g = other.GetComponentInParent<GuardianBehaviour> ();
			int rtrn = g.getState ();


			switch (rtrn) {
			case 1:
				//WindUP
				g.setState (3);
				receiveDamage (guardianDmg, false, true);
				break;
			case 2:
				//PreaparingAttack
				g.DestroyThis ();
				KillEnemyParent ();
				break;
			case 3:
				//AfterCounter
				break;
			case 4:
				//AfterAttack
				receiveDamage (guardianDmg, false, true);
				break;

			}
		}

		if ((other.gameObject.tag == "Bullet" || other.gameObject.tag == "Aimer")) {
			receiveDamage (bulletDmg, false, true);
			//other.SendMessage("DestroyThis", SendMessageOptions.DontRequireReceiver);
		}

		if (other.gameObject.tag == "Boarder") {

//			StopCoroutine ("recoveryRoutine");
//			mat.color = defaultColor;
//			recovering = false;
//			//SetHp to 0
//			receiveDamage (hero.getHp (), true);
			receiveDamage (33, false, false);
			movement.KnockBack ();

		}

		//BOSS
		if (other.gameObject.tag == "BossWeapon") {
			receiveDamage (bulletDmg, false, true);
		}

		if (other.gameObject.tag == "BossSweetspot") {
			sfx.PlayKillSound ();

			other.transform.parent.parent.SendMessage ("setBossSweet", true);
			other.transform.parent.parent.SendMessage ("ReceiveDamage", SendMessageOptions.DontRequireReceiver);
		}

		//Boss 2
		if (other.gameObject.tag == "RipostProjectile") {
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
				other.SendMessage ("Ripost", SendMessageOptions.DontRequireReceiver);
			} else if (!HeroManager.invincible && !recovering) {
				other.SendMessage ("DestroyThis", SendMessageOptions.DontRequireReceiver);
				receiveDamage (bulletDmg, false, true);
			}
		}

		//Boss 3
		if (other.gameObject.tag == "Boss3") {
			other.SendMessage ("ReceiveDamage", SendMessageOptions.DontRequireReceiver);
			sfx.PlayKillSound ();
		}

		if (other.gameObject.tag == "Illusion") {
			other.SendMessage ("Explode", SendMessageOptions.DontRequireReceiver);
			receiveDamage (20, false, true);
		}
	}

	//Destroy
	void DestroyAllX (string target)
	{
		gameObjects = GameObject.FindGameObjectsWithTag (target);
		for (var i = 0; i < gameObjects.Length; i++) {
			Destroy (gameObjects [i]);
		}
	}

	//Just disable (for pooled objects)
	void DisableAllX (string target)
	{
		gameObjects = GameObject.FindGameObjectsWithTag (target);
		for (var i = 0; i < gameObjects.Length; i++) {
			gameObjects [i].SetActive (false);
		}
	}

	void SpawnPopUp (List<GameObject> list)
	{
		int spwnPosition = Random.Range (0, 4);
		int target = Random.Range (0, 16);
		for (int i = 0; i < list.Count; i++) {
			if (!list [target].activeInHierarchy) {

				switch (spwnPosition) {
				case 0:
					list [target].transform.position = new Vector3 (transform.position.x + 3, transform.position.y + 1, 0);
					list [target].transform.rotation = Quaternion.AngleAxis (-30, new Vector3 (0, 0, 1));
					list [target].SetActive (true);
					break;
				case 1:
					list [target].transform.position = new Vector3 (transform.position.x + 3, transform.position.y - 1, 0);
					list [target].transform.rotation = Quaternion.AngleAxis (-30, new Vector3 (0, 0, 1));
					list [target].SetActive (true);
					break;
				case 2:
					list [target].transform.position = new Vector3 (transform.position.x + 1, transform.position.y - 1, 0);
					list [target].transform.rotation = Quaternion.AngleAxis (30, new Vector3 (0, 0, 1));
					list [target].SetActive (true);
					break;
				case 3:
					list [target].transform.position = new Vector3 (transform.position.x + 1, transform.position.y + 1, 0);
					list [target].transform.rotation = Quaternion.AngleAxis (30, new Vector3 (0, 0, 1));
					list [target].SetActive (true);
					break;
				}
			}
		}

	}

	void CheckDeath ()
	{
		if (hero.getHp () <= 0.01) {

			hero.Death ();
			StateManager.dead = true;

			DestroyAllX ("Boss");
			DestroyAllX ("Boss2");
			DestroyAllX ("Boss3");
			//DestroyAllX ("Boss4");
			//DestroyAllX ("Boss5");

			//Disable pooled objects
			DisableAllX ("Bullet");
			DisableAllX ("Villain");
			DisableAllX ("Shooter");
			DisableAllX ("Guardian");
			DisableAllX ("Aimer");
			DisableAllX ("Shadow");
			DisableAllX ("Mime");
			DisableAllX ("Sniper");
			DisableAllX ("PopUp");

			scoreTracking.setBest ();
			scoreTracking.setScore (0);

			Time.timeScale = 0.0f;
		}
	}

	IEnumerator recoveryRoutine ()
	{

		recovering = true;
		mat.color = damageReceived;
		yield return new WaitForSeconds (0.1f);
		mat.color = defaultColor;
		yield return new WaitForSeconds (0.1f);
		mat.color = damageReceived;
		yield return new WaitForSeconds (0.1f);
		mat.color = defaultColor;
		yield return new WaitForSeconds (0.1f);
		mat.color = damageReceived;
		yield return new WaitForSeconds (0.1f);
		mat.color = damageReceived;
		yield return new WaitForSeconds (0.1f);
		mat.color = defaultColor;
		yield return new WaitForSeconds (0.1f);
		mat.color = damageReceived;
		yield return new WaitForSeconds (0.1f);
		mat.color = defaultColor;
		yield return new WaitForSeconds (0.1f);
		mat.color = damageReceived;
		yield return new WaitForSeconds (0.1f);
		mat.color = invincibleColor;
		yield return new WaitForSeconds (1.0f);
		mat.color = defaultColor;
		recovering = false;


	}
}