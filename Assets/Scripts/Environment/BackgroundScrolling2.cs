using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundScrolling2 : MonoBehaviour
{

    public GameObject tile;
    float width;
    public float scrollSpeed;
    List<GameObject> lTiles;
    int amountPooled = 2;
    public bool flipped;
    Vector3 direction;


    // Use this for initialization
    void Start()
    {
		Transform camera2 = GameObject.Find("Camera2").transform;
        lTiles = new List<GameObject>();
        for (int i = 0; i < amountPooled; i++)
        {
            GameObject obj = (GameObject)Instantiate(tile);
			obj.transform.parent = camera2;
            obj.SetActive(false);
            lTiles.Add(obj);

        }
        Renderer renderer = tile.GetComponent<Renderer>();
        width = renderer.bounds.size.x;

        if (flipped) { direction = Vector3.right; }
        else { direction = Vector3.left; }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direction * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= -11.0f)
        {
            if (flipped) { SpawnTile(true); }
            else { SpawnTile(false); }
            DestroyThis();
        }
    }

    void SpawnTile(bool flipped)
    {
        for (int i = 0; i < lTiles.Count; i++)
        {
            if (!lTiles[i].activeInHierarchy)
            {

                lTiles[i].transform.position = new Vector3(this.gameObject.transform.position.x + 2 * width,
                                             this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                if (flipped)
                {
                    lTiles[i].transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    lTiles[i].GetComponent<BackgroundScrolling2>().flipped = true;
                }
                else
                {
                    lTiles[i].transform.rotation = Quaternion.identity;
                    lTiles[i].GetComponent<BackgroundScrolling2>().flipped = false;
                }
                
                lTiles[i].SetActive(true);
                break;
            }
        }
    }

    void DestroyThis()
    {
        gameObject.SetActive(false);
    }

    public void setFlipped()
    {
        flipped = true;
    }
}
