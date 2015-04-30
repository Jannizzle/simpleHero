using UnityEngine;
using System.Collections;

public class Boss2Projectile : MonoBehaviour
{
	public float projSpeed;
	int direction;
		
	// Use this for initialization
	void Start ()
	{
		direction = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{

		transform.Rotate (Vector3.forward * Time.deltaTime * 300.0f * direction, Space.World);

		transform.Translate (Vector3.left * projSpeed * Time.deltaTime, Space.World);

		if (transform.position.x <= -10.0f) {
			DestroyThis ();
		}

				
		
	
	}

	public void Ripost ()
	{
		Debug.Log ("Riposted");
		direction = -1;
		projSpeed -= 2 * projSpeed;
	}

	public void DestroyThis ()
	{
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Boss2") {
			other.SendMessage ("ReceiveDamage", SendMessageOptions.DontRequireReceiver);
			DestroyThis ();
		}
	}
}
