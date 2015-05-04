using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour
{

	public float factor;

	public void setFactorInChildren (float value)
	{
		gameObject.BroadcastMessage ("setFactor", value);
		factor = value;
	}

}
