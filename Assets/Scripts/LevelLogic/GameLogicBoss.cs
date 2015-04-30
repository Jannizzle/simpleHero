using UnityEngine;
using System.Collections;

public class GameLogicBoss : MonoBehaviour
{
	
	
	
	public static bool dead = false;
	public int score = 0;
	public int best = 0;
	public GUIText scoreText;

	//PowerUp Section
	public float pBulletDuration;
	public float pVertigoDuration;
	public float pMagnetDuration;
	
	float pBulletTimer;
	float pVertigoTimer;
	float pMagnetTimer;
	
	
	bool pBulletActive;
	bool pVertigoActive;
	bool pMagnetActive;

	
	// Use this for initialization
	void Start()
	{
		best = PlayerPrefs.GetInt("HighScore");
		scoreText.color = Color.yellow;

		
		
		//Assign PowerUps
	}
	
	// Update is called once per frame
	void Update()
	{
		scoreText.text = "Score: " + score + "  Best: " + best;
	}
	
	public void setVertigo(bool mode)
	{
		pVertigoActive = mode;
		pVertigoTimer = 0.0f;
	}
	
	public void setScore(int mode)
	{
		if (mode == 0)
		{
			score++;
			//score += 9;
		}
		if (mode == 1 && score != 0)
		{
			score--;
		}
		
	}

	
	public void setBest()
	{
		if (score >= best)
		{
			best = score;
			PlayerPrefs.SetInt("HighScore", best);
			
		}
		score = 0;
	}
	
}
