using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTilw : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerEnter(Collider other)
    {
        Material purple = Resources.Load("WinTile", typeof(Material)) as Material;
        gameObject.GetComponent<Renderer>().material = purple;
        Debug.Log("WON");
    }
}