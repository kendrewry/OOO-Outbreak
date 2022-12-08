using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{

    public GameObject fps;
    
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider bc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        bc.size = new Vector3(12f, 5f, 12f);
        bc.isTrigger = true;
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    private void OnTriggerEnter(Collider other)
    {
            fps.transform.position = new Vector3(0f, 5f, 0f);
    }
}
