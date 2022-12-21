using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerProblem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PROBLEM TRIGGERED");
    }
}
