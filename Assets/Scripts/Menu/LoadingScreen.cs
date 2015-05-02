using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{


	public Text bar;

	// Use this for initialization
	void Start ()
	{
		Application.LoadLevel(1);
	}

}
