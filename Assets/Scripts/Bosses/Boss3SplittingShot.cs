using UnityEngine;
using System.Collections;

public class Boss3SplittingShot : MonoBehaviour {


    Transform child1;
    Transform child2;
    public float speed;
    public int frameCounter;
    public int splittingPoint;

	// Use this for initialization
	void Start () {

        frameCounter = 0;
        child1 = transform.FindChild("Shot1");
        child2 = transform.FindChild("Shot2");

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        frameCounter++;
        child1.transform.Translate(-Vector2.right * Time.deltaTime * speed);
        child2.transform.Translate(-Vector2.right * Time.deltaTime * speed);
        if(frameCounter >= splittingPoint)
        {
            child1.transform.rotation = Quaternion.Euler(0,0,45);
            child2.transform.rotation = Quaternion.Euler(0, 0, -45);
            
        }

        if (frameCounter >= 300)
        {
            Destroy(gameObject);
        }

	
	}
}
