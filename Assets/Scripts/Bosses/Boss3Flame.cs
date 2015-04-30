using UnityEngine;
using System.Collections;

public class Boss3Flame : MonoBehaviour
{

    public float factor;
    public Sprite vertigo;
    public Sprite summon;
    public Sprite doubleShot;
    public Sprite splittingShot;
    SpriteRenderer rend;


    // Use this for initialization
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, factor);
    }

    public void setVertigo()
    {
        if (rend == null) { rend = gameObject.GetComponent<SpriteRenderer>(); }
        rend.sprite = vertigo;
    }
    public void setSummon()
    {
        if (rend == null) { rend = gameObject.GetComponent<SpriteRenderer>(); }
        rend.sprite = summon;
    }
    public void setDoubleShot()
    {
        if (rend == null) { rend = gameObject.GetComponent<SpriteRenderer>(); }
        rend.sprite = doubleShot;
    }
    public void setSplittingShot()
    {
        if (rend == null) { rend = gameObject.GetComponent<SpriteRenderer>(); }
        rend.sprite = splittingShot;
    }
}
