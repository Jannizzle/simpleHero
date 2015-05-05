//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class BackgroundScrolling2 : MonoBehaviour
//{
//
//	public GameObject tile;
//	float width;
//	public float scrollSpeed;
//	public float factor;
//	public float target;
//	List<GameObject> lTiles;
//	int amountPooled = 2;
//	public bool flipped;
//	Vector3 direction;
//	ParallaxManager pm;
//
//
//	// Use this for initialization
//	void Start ()
//	{
//		Renderer renderer = tile.GetComponent<Renderer> ();
//		width = renderer.bounds.size.x;
//		factor = 1.0f;
//		target = 1.0f;
//		if (flipped) {
//			direction = Vector3.right;
//		} else {
//			direction = Vector3.left;
//		}
//	}
//
//	// Update is called once per frame
//	void Update ()
//	{
//		transform.Translate (direction * scrollSpeed * ((float)factor / 1000) * Time.deltaTime);
//		if (transform.position.x <= -11.0f) {
//			if (flipped) {
//				SpawnTile (true);
//			} else {
//				SpawnTile (false);
//			}
//			DestroyThis ();
//		}
//	}
//	
//
//	void DestroyThis ()
//	{
//		gameObject.SetActive (false);
//	}
//
//	public void setFlipped ()
//	{
//		flipped = true;
//	}
//
//	public void setTarget (int value)
//	{
//		target = value;
//	}
//
//	public void LerpFactor (int target)
//	{
//		while (factor != target) {
//			if (factor < target) {
//				factor++;
//			} else {
//				factor--;
//			}
//		}
//
//	}
//}
