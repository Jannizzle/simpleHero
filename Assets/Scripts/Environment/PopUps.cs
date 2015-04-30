using UnityEngine;
using System.Collections;

public class PopUps : MonoBehaviour
{
		public float scrollSpeed;
		public float duration = 0.0f;
		float counter = 0.0f;

		void OnEnable ()
		{
				
				transform.localScale += new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f), 1.0f);
		}

		// Update is called once per frame
		void Update ()
		{
				transform.Translate (Vector3.left * scrollSpeed * Time.deltaTime, Space.World);
				counter += Time.deltaTime;

				if (counter >= duration) {
						DisableThis ();
				}

		}

		void OnDisable ()
		{
				counter = 0.0f;
		}

		void DisableThis ()
		{
				gameObject.SetActive (false);
		}
}
