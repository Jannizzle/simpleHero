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

	public void setHp (int value)
	{
		hp = value;
		gui.updateHP (hp, maxHp);
	}

	public int getHp ()
	{
		return hp;
	}

	public int getMaxHp ()
	{
		return maxHp;
	}

	public void receiveDamage (int dmg)
	{
		hp -= dmg;
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
