using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{

    Vector2 correction;
    public float ascendingV;

    public GameObject touchArea;
    InputArea inputArea;

    public GameObject button;
    Button inputButton;

    bool performingAttack;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("InputArea");
        touchArea = tmp;
        inputArea = touchArea.GetComponent<InputArea>();
        inputArea.bindHero();

        GameObject tmp2 = GameObject.FindGameObjectWithTag("Button");
        button = tmp2;
        inputButton = button.GetComponent<Button>();
        inputButton.bindHero();

        animator = gameObject.GetComponentInChildren<Animator>();

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("s"))
        {
            Attack();
        }

        if (Input.GetKey("p"))
        {
            Ascend();
        }

        if (transform.position.x <= -4)
        {
            correctPosition();
        }

    }

    void correctPosition()
    {
        correction.x = -4 - transform.position.x;
        transform.Translate(correction * Time.deltaTime);
    }

    public void Ascend()
    {

		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ascendingV);
        
    }

    public void knockBack()
    {

        Debug.Log("OUCH");
    }

    public void Attack()
    {
        performingAttack = true;
        animator.SetBool("performingAttack", true);
    }

    public void endAttack()
    {
        performingAttack = false;
        animator.SetBool("performingAttack", false);
    }
}
