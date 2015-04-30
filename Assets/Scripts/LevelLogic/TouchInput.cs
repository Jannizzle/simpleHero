using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach (Touch Touch in Input.touches) {
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Touch.position);
			RaycastHit hit;


			if(Physics.Raycast(ray, out hit, touchInputMask)){
				GameObject recipient = hit.transform.gameObject;

				if(Touch.phase == TouchPhase.Stationary || Touch.phase == TouchPhase.Moved){
					recipient.SendMessage("isTouched", SendMessageOptions.DontRequireReceiver);

				}

				
				if(Touch.phase == TouchPhase.Ended){
					recipient.SendMessage("TouchEnded", SendMessageOptions.DontRequireReceiver);
					
				}
			}
				}
	
	}
}
