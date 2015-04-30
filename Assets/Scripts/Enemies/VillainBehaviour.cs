using UnityEngine;
using System.Collections;

public class VillainBehaviour : MonoBehaviour
{

    public float villainSpeed;
    public float pMagnetSpeed;
    public float pMagnetDuration;
    public float pMagnetTimer;
    GameObject gate;
    public GameObject hero;
    bool pMagnetActive;

    // Use this for initialization
    void Start()
    {
        
    }

	void OnEnable()
	{

	}

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.left * villainSpeed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            DestroyThis();
        }
        if (pMagnetActive)
        {
            Debug.Log("Activated");
            //transform.Translate(hero.transform.position * villainSpeed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, 20);
            gameObject.GetComponent<Rigidbody2D>().AddForce((hero.transform.position - transform.position) * pMagnetSpeed * Time.smoothDeltaTime);
            pMagnetTimer += Time.deltaTime;

            if (pMagnetTimer >= pMagnetDuration)
            {
                pMagnetActive = false;
                pMagnetTimer = 0.0f;
            }
        }
        else
        {
            //transform.Translate(Vector3.left * villainSpeed * Time.deltaTime);
        }
    }

    void BindGate(GameObject other)
    {
        gate = other;
    }

    void DestroyThis()
    {
        
		gameObject.SetActive (false);

    }

    public void setMagnet()
    {
        pMagnetActive = true;
    }
}
