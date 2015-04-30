using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

    public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
	}
}
