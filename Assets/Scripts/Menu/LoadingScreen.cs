using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{


	public Text text;
	public Image bar;
	float originalScale;
	int tmp;
	// Use this for initialization
	void Start ()
	{
		originalScale = bar.rectTransform.localScale.x;
		//Application.LoadLevel(1);
		StartCoroutine (load ());
	
	}

	void Update ()
	{
		//bar.text = ""+tmp;
	}

	IEnumerator load ()
	{

		AsyncOperation async = Application.LoadLevelAsync (1);
		while (!async.isDone) {
			text.text = "Progress " + (int)(async.progress * 100) + "%";
			bar.rectTransform.localScale = new Vector3 (async.progress * originalScale, bar.rectTransform.localScale.y, 1);

			yield return null;
		}


	}

}
