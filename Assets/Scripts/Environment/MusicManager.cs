using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

	public AudioClip track1;
	public AudioClip bossFight;
	public AudioSource source;

	public void playTrack (int num)
	{
		switch (num) {
		case 1:
			source.clip = track1;
			if (!source.isPlaying) {
				source.Play ();
			}
			break;
		case 666:
			source.clip = bossFight;
			if (!source.isPlaying) {
				source.Play ();
			}
			break;
		}
	}
}
