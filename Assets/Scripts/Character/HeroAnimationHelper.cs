using UnityEngine;
using System.Collections;

public class HeroAnimationHelper : MonoBehaviour
{

	MovementController parent;

	void Start ()
	{
		parent = gameObject.GetComponentInParent<MovementController> ();
	}

	void endAttack ()
	{
		parent.endAttack ();
	}

}
