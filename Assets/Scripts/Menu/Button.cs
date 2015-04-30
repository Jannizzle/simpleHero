using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    public GameObject hero;
    MovementController mc;
    Material mat;
    public Color defaultColor;
    public Color pressedColor;
    Camera camera;
    public float viewportPosx;
    public float viewportPosy;
    [Range(0, 1)]
    public float buttonSize;
    float size;
    Vector3 pos;
    public bool pressed;
    public Sprite sPressed;
    public Sprite sUnpressed;
    SpriteRenderer rend;



    // Use this for initialization
    void Start()
    {
        //mat = renderer.material;
        rend = gameObject.GetComponent<SpriteRenderer>();
        sUnpressed = rend.sprite;
        bindHero();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        pos = camera.ViewportToWorldPoint(new Vector3(viewportPosx, viewportPosy, 10));
        transform.position = pos;

        Vector3 factor = camera.ViewportToWorldPoint(new Vector3(buttonSize, 0, 10)) - camera.ViewportToWorldPoint(new Vector3(0, 0, 10));
        size = transform.localScale.x * factor.x;
        transform.localScale = new Vector3(size, size, 1);

    }

    void Update()
    {


        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Input 0");
        //    //hero.SendMessage ("Ascend");
        //    mc.Attack();
        //    mat.color = pressedColor;
        //}
        //else
        //{
        //    mat.color = defaultColor;
        //}

    }

    void TouchEnded()
    {
        //mat.color = defaultColor;
        pressed = false;
        rend.sprite = sUnpressed;
    }

    public void isTouched()
    {
        if (Time.timeScale == 1.0f && !pressed)
        {
            mc.Attack();
            pressed = true;
        }

        //mat.color = pressedColor;
        rend.sprite = sPressed;

    }

    public void bindHero()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("Hero");
        hero = tmp;
        mc = hero.GetComponent<MovementController>();
    }

    public void ResetPos()
    {
        pos = camera.ViewportToWorldPoint(new Vector3(viewportPosx, viewportPosy, 10));
        transform.position = pos;
    }
}
