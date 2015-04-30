using UnityEngine;
using System.Collections;

public class Boss3Illusion : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Explode()
    {
        animator.Play("Exploding");
    }

    public void DieAlready()
    {
        Destroy(gameObject);
    }
}
