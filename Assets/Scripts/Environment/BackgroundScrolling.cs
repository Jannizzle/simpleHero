using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour
{
	public int id;
	float direction;
	float scrollSpeed;
	public float factor;
	public float target = 1.0f;
	public bool flipped;
	float width;
	ParallaxManager pm;
	
	// Use this for initialization
	void Start ()
	{
		pm = gameObject.GetComponentInParent<ParallaxManager> ();
		scrollSpeed = pm.getScrollSpeed (id);
		factor = 1.0f;
		target = 1.0f;
		width = gameObject.GetComponent<Renderer> ().bounds.size.x;
		if (flipped) {
			direction = -1;
		} else {
			direction = 1;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		factor = Mathf.Lerp(factor, target, 0.01f);
		transform.Translate (Vector3.left * direction * scrollSpeed * factor * Time.deltaTime);

		if (transform.position.x <= -11.0f) {
			transform.position = new Vector3 (this.gameObject.transform.position.x + 2 * width,
			                                                                              this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}
	}
	
	void DestroyThis ()
	{
		gameObject.SetActive (false);
	}
	
	public void setFlipped ()
	{
		flipped = true;
	}
	
	public void LerpFactor (float target)
	{
		Mathf.Lerp (factor, target, Time.time);		
	}

	public void setTarget (float value)
	{
		target = value; 
	}
}