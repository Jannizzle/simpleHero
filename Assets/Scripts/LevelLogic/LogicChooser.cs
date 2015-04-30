using UnityEngine;
using System.Collections;

public class LogicChooser : MonoBehaviour {


	LevelManager levelManger;
    TestSceneLogic testLogic;
	// Use this for initialization
	void Start () {

        if (Application.loadedLevelName == "Level1")
        {
			levelManger = GetComponent<LevelManager>();
			levelManger.enabled = true;
		}
        if (Application.loadedLevelName == "Test" || Application.loadedLevelName == "Boss")
        {
            testLogic = (TestSceneLogic)GetComponent("TestSceneLogic");
            testLogic.enabled = true;
        }

	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
