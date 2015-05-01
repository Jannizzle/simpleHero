using UnityEngine;
using System.Collections;

public class ShadowBehaviour : MonoBehaviour
{

    public float decloakRange;
    public float movementSpeed;
    public Color cloaked;
    public Color opaque;

    // Use this for initialization
    void Start()
    {

        gameObject.GetComponent<Renderer>().material.color = cloaked;
    }

    void OnEnable()
    {
		gameObject.GetComponent<Renderer>().material.color = cloaked;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        if (transform.position.x <= decloakRange)
        {
			gameObject.GetComponent<Renderer>().material.color = opaque;
        }


        if (transform.position.x <= -10)
        {
            DestroyThis();
        }


    }

    void DestroyThis()
    {
        gameObject.SetActive(false);
    }
}
