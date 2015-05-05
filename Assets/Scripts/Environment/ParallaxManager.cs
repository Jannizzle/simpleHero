using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{

	public float factor;
	float target;
	int amountPooled;
	List<GameObject> lTiles;
	public GameObject backA;
	public GameObject backB;
	public GameObject backX;
	public GameObject backY;
	public GameObject midA;
	public GameObject midB;
	public GameObject midX;
	public GameObject midY;
	float widthBack;
	float widthMid;
	public float speedBack;
	public float speedMid;
	bool flipped;
	Vector3 direction;

	void Start ()
	{
		Renderer renderer = backA.GetComponent<Renderer> ();
		widthBack = renderer.bounds.size.x;
		renderer = midA.GetComponent<Renderer> ();
		widthMid = renderer.bounds.size.x;
	}

	public float getScrollSpeed (int id)
	{
		switch (id) {
		case 0:
			return speedBack;
		case 1:
			return speedBack;
		case 2:
			return speedBack;
		case 3:
			return speedBack;
		case 4:
			return speedMid;
		case 5:
			return speedMid;
		case 6:
			return speedMid;
		case 7:
			return speedMid;
		}
		return 0;
	}

	public void TellChildren (float target)
	{
		BroadcastMessage ("setTarget", target);
	}

}
