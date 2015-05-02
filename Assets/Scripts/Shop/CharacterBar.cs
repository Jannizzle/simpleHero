using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterBar : MonoBehaviour
{

	public int[] positions;
	public int pointer = 0;
	public int characters;
	public Text title;
	public Text desc;
	string name1 = "Batman";
	string name2 = "Boba Fett";
	string name3 = "Deadpool";
	string name4 = "Hulk";
	string name5 = "Ironman";
	string name6 = "Mystique";
	string name7 = "Robin";
	string desc1 = "Super mega dark und mysterious. Killt krass, fliegt fett. Muss man haben.";
	string desc2 = "Super mega fies und söldnerisch. Killt hart, fliegt mit Jetpack. Muss man haben.";
	string desc3 = "Super mega lustig und naja. Killt außergewöhnlich, fliegt gar nicht. Muss man haben.";
	string desc4 = "Super mega stark und breit. Matscht krass, lässt fliegen. Muss man haben.";
	string desc5 = "Super mega reich und rot. Killt krass, fliegt mit Anzug. Muss man nicht haben.";
	string desc6 = "Super mega mysterious und mysterious. Killt krass, fliegt nicht. Muss man unbedingt haben.";
	string desc7 = "Super mega belanglos. Killt nicht, fliegt nicht. Kauft lieber Batman.";

	void Start ()
	{
		pointer = 0;
		positions = new int[characters];
		for (int i = 0; i < positions.Length; i++) {
			positions [i] = i * (-3);
		}
		title.text = getTitle (pointer);
		desc.text = getDesc (pointer);
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown ("d")) {
			NavigateRight ();
		}
		if (Input.GetKeyDown ("a")) {
			NavigateLeft ();
		}
	
	}

	string getTitle (int pointer)
	{
		switch (pointer) {
		case 0:
			return name1;
		case 1:
			return name2;
		case 2:
			return name3;
		case 3:
			return name4;
		case 4:
			return name5;
		case 5:
			return name6;
		case 6:
			return name7;
		}
		return "";
	}

	string getDesc (int pointer)
	{
		switch (pointer) {
		case 0:
			return desc1;
		case 1:
			return desc2;
		case 2:
			return desc3;
		case 3:
			return desc4;
		case 4:
			return desc5;
		case 5:
			return desc6;
		case 6:
			return desc7;
		}
		return "";
	}

	public void NavigateLeft ()
	{
		if (pointer > 0) {
			pointer--;
			transform.position = new Vector3 (positions [pointer], transform.position.y, 0); 
			title.text = getTitle (pointer);
			desc.text = getDesc (pointer);
		}
	}

	public void NavigateRight ()
	{
		if (pointer < positions.Length - 1) {
			pointer++;
			transform.position = new Vector3 (positions [pointer], transform.position.y, 0);
			title.text = getTitle (pointer);
			desc.text = getDesc (pointer);
		}
	}
}
