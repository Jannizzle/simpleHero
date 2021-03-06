﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracking : MonoBehaviour
{

	int currentScore;
	int killCount;
	int currentLevel;
	int bestScore;
	int threshold;
	float multiplier;
	public Text levelText;
	public Text nextLevelText;
	public Text scoreText;
	public Text multiText;
	ParallaxManager pm;

	// Use this for initialization
	void Start ()
	{
		bestScore = PlayerPrefs.GetInt ("HighScore");
		scoreText.color = Color.yellow;
		currentLevel = 1;
		multiplier = 1.0f;
		threshold = 2;
		GameObject tmp = GameObject.FindGameObjectWithTag ("Camera2");
		if(tmp != null)
		pm = tmp.GetComponent<ParallaxManager> ();


	}
	
	// Update is called once per frame
	void Update ()
	{
				
				
		levelText.text = "Lv: " + currentLevel;
		nextLevelText.text = "NextAt: " + (threshold - killCount);
		scoreText.text = "Score: " + currentScore;
				
		if (multiplier == 1.0f) {
			multiText.text = "";
		} else {
			multiText.text = "x " + multiplier;
		}
	
	}

	public void incrementKillCount ()
	{
		killCount++;
	}

	public void riseMultiplier ()
	{
		multiplier += 0.1f;
		if (multiplier >= 1.2f && multiplier < 1.4f) {
			pm.TellChildren (1.2f);
		}
		if (multiplier >= 1.4f && multiplier < 1.6f) {
			pm.TellChildren (1.4f);
		}
		if (multiplier >= 1.6f && multiplier < 1.8f) {
			pm.TellChildren (1.6f);
		}
		if (multiplier >= 1.8f && multiplier < 2.0f) {
			pm.TellChildren (1.8f);
		}
		if (multiplier >= 2.0f && multiplier < 2.2f) {
			pm.TellChildren (2.0f);
		}
		if (multiplier >= 2.2f && multiplier < 2.4f) {
			pm.TellChildren (2.2f);
		}
		if (multiplier >= 2.4f && multiplier < 2.6f) {
			pm.TellChildren (2.4f);
		}
		if (multiplier >= 2.6f && multiplier < 2.8f) {
			pm.TellChildren (2.6f);
		}
		if (multiplier >= 2.8f && multiplier < 3.0f) {
			pm.TellChildren (2.8f);
		}
		if (multiplier >= 3.0f && multiplier < 5.0f) {
			pm.TellChildren (3.0f);
		}
	}

	public void resetMultiplier ()
	{
		multiplier = 1.0f;
		pm.TellChildren (1.0f);
	}

	public void setScore (int value)
	{
		currentScore = value;
	}
		
	public void AddScore (float value)
	{
		currentScore += Mathf.RoundToInt (multiplier * value); 
	}

	public void setLevel (int value)
	{
		currentLevel = value;
	}

	public void setBest ()
	{
		if (currentScore >= bestScore) {
			bestScore = currentScore;
			PlayerPrefs.SetInt ("HighScore", bestScore);
			
		}
		currentScore = 0;

	}

	public int getCurrentScore ()
	{
		return currentScore;
	}

	public int getCurrentKillCount ()
	{
		return killCount;
	}

	public void setThreshold (int value)
	{
		threshold = value;
		killCount = 0;
	}

	public void Restart ()
	{
		currentLevel = 1;
		threshold = 2;
		currentScore = 0;
		killCount = 0;
	}

}
