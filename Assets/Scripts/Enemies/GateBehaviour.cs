using UnityEngine;
using System.Collections;

public class GateBehaviour : MonoBehaviour
{
    public float gateSpeed;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * gateSpeed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
