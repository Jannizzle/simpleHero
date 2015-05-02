using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
	

	public void NavigateTo(string toScene){
		switch (toScene){
		case "title":
			Application.LoadLevel(0);
			break;
		case "level1":
			Application.LoadLevel(3);
			break;
		case "shop":
			Application.LoadLevel(2);
			break;
		}
	}
}
