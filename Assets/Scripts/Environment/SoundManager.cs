using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{


	public AudioSource source;
	public AudioClip[] punches;
	public AudioClip[] shouts;

	void Update ()
	{

//		if (Input.GetKeyDown ("m")) {
//			StartCoroutine("OnEnemyKill");
//		}

	}

	public void PlayKillSound ()
	{
		StartCoroutine ("OnEnemyKill");
	}

	IEnumerator OnEnemyKill ()
	{
		int rnd1 = Random.Range (0, punches.Length);
		int rnd2 = Random.Range (0, shouts.Length);

		source.PlayOneShot (punches [rnd1]);
		yield return new WaitForSeconds (0.1f);
		source.PlayOneShot (shouts [rnd2]);

		//source.PlayDelayed (punches [rnd1].length);

	}

}