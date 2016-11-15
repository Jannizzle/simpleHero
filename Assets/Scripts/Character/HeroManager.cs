using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour
{

	int hp;
	public int maxHp;
	MyGUI gui;
	public static bool invincible;
	Animator animator;
	Transform child;

	// Use this for initialization
	void Start ()
	{
		gui = GameObject.Find ("MainCamera").GetComponent<MyGUI> ();
		hp = maxHp;
		gui.updateHP (hp, maxHp);
		animator = gameObject.GetComponentInChildren<Animator> ();
		child = transform.FindChild ("Hero");

	}

	public void SetHp (int value)
	{
		hp = value;
		gui.updateHP (hp, maxHp);
	}

	public int GetHp ()
	{
		return hp;
	}

	public int GetMaxHp ()
	{
		return maxHp;
	}

	public void ReceiveDamage (int dmg)
	{
		hp -= dmg;
		if (hp < 0) {
			hp = 0;
		}
		gui.updateHP (hp, maxHp);
	}

	public void AddHealth (int amount)
	{
		hp += amount;
		if (hp > maxHp) {
			hp = maxHp;
		}
		gui.updateHP (hp, maxHp);
	}

	public void Death ()
	{
		gameObject.SetActive (false);
		child.position = transform.position;
	}

	public void Respawn ()
	{
		StateManager.dead = false;
		gameObject.transform.position = new Vector3 (-10, 0, 0);
		gameObject.SetActive (true);
		hp = maxHp;
		gui.updateHP (hp, maxHp);
	}

}
