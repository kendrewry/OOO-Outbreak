using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTiles : MonoBehaviour
{
    public GameObject respawn;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("stepped on Fake");
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        respawn.GetComponent<RandomizeMap>().question.text = "";
        Destroy(this.gameObject);
    }
}
