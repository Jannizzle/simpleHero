using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	public  AudioClip title;
	public AudioClip shop;
	public AudioClip track1;
	public AudioClip track2;
	public AudioClip bossFight;
	public AudioSource source;

	public void playTrack (int num)
	{
		switch (num) {
		case 0:
			source.clip = title;
			if (!source.isPlaying) {
				source.Play ();
			}
			break;
		case 1:
			source.clip = track1;
			if (!source.isPlaying) {
				source.Play ();
			}
			break;
		case 2:
			source.clip = track2;
			if (!source.isPlaying) {
				source.Play ();
			}
			break;
		case 9:
			source.clip = shop;
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
