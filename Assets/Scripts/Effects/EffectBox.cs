using UnityEngine;
using System.Collections;

public class EffectBox : MonoBehaviour
{

    public Camera camera;
    public Camera camera2;
    Button aButton;
    int frameCounter;
    public int vertigoDuration;

    // Use this for initialization
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("Button");
        aButton = tmp.GetComponent<Button>();
        GameObject tmp2 = GameObject.FindGameObjectWithTag("Camera2");
		if (tmp2 != null) {
			camera2 = tmp2.GetComponent<Camera> ();
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            Vertigo();
        }

        if (StateManager.vertigo)
        {
            frameCounter++;

            if (frameCounter >= vertigoDuration)
            {
                Vertigo();
                frameCounter = 0;
            }
        }

        //				if (camera.transform.localEulerAngles.z < 180.0f)
        //						
        //						camera.transform.Rotate (0, 0, 3);
        //				else {
        //						camera.transform.rotation = Quaternion.Slerp (new Quaternion (0, 0, 0, 0), new Quaternion (0, 0, 180, 0), 1000.0f * Time.deltaTime);
        //				}


    }

    public void Vertigo()
    { 
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
        camera2.projectionMatrix = camera2.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
        if (!StateManager.vertigo) { StateManager.vertigo = true; }
        else { StateManager.vertigo = false; }
        aButton.ResetPos();

        
    }
}
