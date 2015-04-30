using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{

	public static bool dead = false;
	public static bool vertigo = false;
	public static bool gamePaused = false;

	public static void PauseGame ()
	{

		if (!gamePaused) {
			gamePaused = true;
			Time.timeScale = 0.0f;
		} else {
			gamePaused = false;
			Time.timeScale = 1.0f;
		}
		
	}

}
