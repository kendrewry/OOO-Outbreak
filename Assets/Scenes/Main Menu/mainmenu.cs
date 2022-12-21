using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void MoveToScene(int sceneID) 
    {
        SceneManager.LoadScene(sceneID);
    }

    public void doExitGame() {
        Application.Quit();
        Debug.Log("Exiting");
    }

    public void Beginner() {
        Debug.Log("Succesfully set difficulty to Beginner");
        SceneManager.LoadScene(3);
    }

    public void Intermediate() {
        Debug.Log("Succesfully set difficulty to Intermediate");
        SceneManager.LoadScene(2);
    }

    public void Extreme() {
        Debug.Log("Succesfully set difficulty to Extreme");
        SceneManager.LoadScene(3);
    }

    public void Tutorial() {
        Debug.Log("Starting Tutorial");
        SceneManager.LoadScene(1);
    }
}
