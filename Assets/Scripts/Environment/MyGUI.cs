using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour
{
	public GUIStyle custom;
	HeroManager hero;
	public Texture tex;
	public Texture mute;
	public AudioSource aS;
	bool stopped;
	Vector2 hpPos;
	Vector2 hpSize;
	float scale;
	public Image hpEmpty;
	public Image hpFull;
	public Text hpValue;
	float orignalSize;
	MovementController move;
	LevelManager cll;
	public Text clockText;
	float rawSec;
	int min;
	int sec;
	public GameObject pauseText;

	void Start ()
	{
		hero = GameObject.Find ("NewHero").GetComponent<HeroManager> ();
		scale = 1.0f;
		orignalSize = hpFull.rectTransform.localScale.x;
		//updateHP (hero.getHp ());
		//hpPos = new Vector2 (Screen.width / 8, Screen.width / 8);
		//	hpSize = new Vector2 (Screen.width / 2, Screen.width / 16);
		cll = GetComponent<LevelManager> ();

	}

	void Update ()
	{


		rawSec += Time.deltaTime;
		min = (int)rawSec / 60;
		sec = (int)rawSec % 60;
		clockText.text = string.Format ("{0:00}:{1:00}", min, sec);

		if (StateManager.gamePaused) {
			pauseText.SetActive (true);
		} else if (pauseText.activeInHierarchy) {
			pauseText.SetActive (false);
		}


	}

	void OnGUI ()
	{

		//Respawn Button:
		if (StateManager.dead) {
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), tex) || Input.GetKey ("return")) {
				hero.Respawn ();
				//Instantiate(hero, new Vector3(-10, 0, 0), Quaternion.identity);
				if (Application.loadedLevelName == "Level1") {
					cll.Restart ();
				}
				rawSec = 0.0f;
				min = (int)rawSec / 60;
				sec = (int)rawSec % 60;
				clockText.text = string.Format ("{0:00}:{1:00}", min, sec);
				Time.timeScale = 1.0f;
			}

		}

	
	}

	public void updateHP (int value)
	{
		scale = (float)value / (float)hero.getMaxHp ();
		hpValue.text = "" + value + "/" + hero.getMaxHp ();
		hpFull.rectTransform.localScale = new Vector3 (orignalSize * scale, hpFull.rectTransform.localScale.y, 1.0f);
	}

	public void ToggleMusic ()
	{
		if (!stopped) {
			aS.Stop ();
			stopped = true;
		} else {
			aS.Play ();
			stopped = false;
		}

	}
}
