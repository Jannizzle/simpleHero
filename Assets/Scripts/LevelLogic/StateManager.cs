using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{

	public static bool dead = false;
	public static bool vertigo = false;
	public static bool gamePaused = false;


	public static void PauseGame ()
	{
		if (!gamePaused && !dead) {
			gamePaused = true;
			Time.timeScale = 0.0f;
		} else if(!dead) {
			gamePaused = false;
			Time.timeScale = 1.0f;
		}
		
	}

}
