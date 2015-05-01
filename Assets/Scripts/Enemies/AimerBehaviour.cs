using UnityEngine;
using System.Collections;

public class AimerBehaviour : MonoBehaviour
{


    GameObject player;
    public int framecount;
    public int chargingTime;
    public float movementSpeedV;
    public float movementSpeedH;
    Vector2 target;
    public float lockHeight;
    public float damage;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Hero");
        framecount = 0;

    }
	

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x > lockHeight)
        {

            transform.Translate(Vector3.left * movementSpeedH * Time.deltaTime);
        }
        else
        {
            framecount++;

            if (framecount <= chargingTime)
            {
                target = new Vector2(transform.position.x, player.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, movementSpeedV * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * movementSpeedH * Time.deltaTime);
            }

        }


        if (transform.position.x <= -10)
        {
            DestroyThis();
        }
    }

    void DestroyThis()
    {
		framecount = 0;
        gameObject.SetActive(false);
    }
}
