using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSceneLogic : MonoBehaviour {

    public float spawnRangeY;

    public GameObject villain;
    public GameObject shooter;
    public GameObject guardian;
    public GameObject bullet;
	public GameObject mime;
	public GameObject aimer;
	public GameObject shadow;
	public GameObject sniper;

	public GameObject boss;
	public GameObject boss2;
	public GameObject boss3;

	string input;


    //Pooling
    int amountPooled = 10;
    public List<GameObject> villains;
    public List<GameObject> shooters;
    public List<GameObject> guardians;
    public List<GameObject> bullets;

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("1")){
			Instantiate(villain,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("2")){
			Instantiate(shooter,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("3")){
			Instantiate(guardian,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("4")){
			Instantiate(aimer,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("5")){
			Instantiate(mime,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("6")){
			Instantiate(shadow,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("7")){
			Instantiate(sniper,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("8")){
			Instantiate(boss,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("9")){
			Instantiate(boss2,new Vector3(10,0,0), Quaternion.identity);
		}
		if(Input.GetKeyDown("0")){
			Instantiate(boss3,new Vector3(6.72f,0,0), Quaternion.identity);
		}
	
	}

    public void Spawn(List<GameObject> list, float y)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {

                list[i].transform.position = new Vector3(10.0f, (y * spawnRangeY) - spawnRangeY / 2, 0.0f);
                list[i].transform.rotation = Quaternion.identity;
                list[i].SetActive(true);
                break;
            }
        }
    }

    public void SpawnAtPosition(List<GameObject> list, float x, float y)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {

                list[i].transform.position = new Vector3(x, y, 0.0f);
                list[i].transform.rotation = Quaternion.identity;
                list[i].SetActive(true);
                break;
            }
        }
    }

}
