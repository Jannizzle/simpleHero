using UnityEngine;
using System.Collections;

public class Boss3Villain : MonoBehaviour {

    public float villainSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * villainSpeed * Time.deltaTime);
        if (transform.position.x <= -10)
        {
            DestroyThis();
        }
	
	}

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
