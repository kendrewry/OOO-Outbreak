using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doExitGame() {
        Application.Quit();
        Debug.Log("Exiting");
    }

    public void Beginner() {
        Debug.Log("Succesfully set difficulty to Beginner");
    }

    public void Intermediate() {
        Debug.Log("Succesfully set difficulty to Intermediate");
    }

    public void Extreme() {
        Debug.Log("Succesfully set difficulty to Extreme");
    }

    public void Tutorial() {
        Debug.Log("Starting Tutorial");
    }
}
