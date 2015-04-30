using UnityEngine;
using System.Collections;

public class MimeBehaviour : MonoBehaviour
{

    public float movementSpeed;
    public float lockHeight;
    public Animator animator;
    GameObject player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x, player.transform.position.y);
        if (transform.position.x > lockHeight)
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        else
        {
            animator.Play("Mime_Tricks");
        }


        if (transform.position.x <= -10)
        {
            DestroyThis();
        }


    }

    public void DestroyThis()
    {
        gameObject.SetActive(false);
    }
}
