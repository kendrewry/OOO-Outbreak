using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningTilw : MonoBehaviour
{
    public GameObject respawn;
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
        SceneManager.LoadScene(4);
        
    }
}