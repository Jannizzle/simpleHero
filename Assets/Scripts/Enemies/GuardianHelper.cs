using UnityEngine;
using System.Collections;

public class GuardianHelper : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
	
	}

	void setState(int state){
		transform.parent.GetComponent<GuardianBehaviour>().setState(state);
	}

	void destroyThis(){
		transform.parent.GetComponent<GuardianBehaviour>().DestroyThis();
	}


}
