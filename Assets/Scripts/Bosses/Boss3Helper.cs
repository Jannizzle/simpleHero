using UnityEngine;
using System.Collections;

public class Boss3Helper : MonoBehaviour
{

    Boss3Behaviour parentObject;
    public GameObject illusion;
    Color defaultColor;
    public Color damageReceived;
    Material mat;
    SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        parentObject = this.gameObject.GetComponentInParent<Boss3Behaviour>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
		mat = renderer.material;
        defaultColor = mat.color;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void setState(int state)
    {

    }

    void PerformAttack()
    {
        parentObject.PerformAttack();
    }

    void ChooseEffect()
    {
        parentObject.ChooseEffect();
    }

    void Blink()
    {
        parentObject.Blink();
    }

    public void ChoosePattern()
    {
        parentObject.ChoosePattern();
    }

    IEnumerator RecoveryRoutine()
    {

		gameObject.GetComponent<Collider2D> ().enabled = false;
        for (int i = 0; i <= 5; i++)
        {
            mat.color = damageReceived;
            yield return new WaitForSeconds(0.1f);
            mat.color = defaultColor;
            yield return new WaitForSeconds(0.1f);
        }
        //    mat.color = damageReceived;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = defaultColor;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = damageReceived;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = defaultColor;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = damageReceived;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = damageReceived;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = defaultColor;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = damageReceived;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = defaultColor;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = damageReceived;
        //yield return new WaitForSeconds(0.1f);
        //mat.color = defaultColor;

		gameObject.GetComponent<Collider2D> ().enabled = true;
    }

    public void ReceiveDamage()
    {
        parentObject.ReceiveDamage();
        StartCoroutine("RecoveryRoutine");
    }

    public void DieAlready()
    {
        parentObject.DieAlready();
    }



}
