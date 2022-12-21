using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed;
    public int randInt;
    // Start is called before the first frame update
    void Start()
    {
        randInt = Random.Range(0,2);
        speed = Random.Range(0.5f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    { 
        if(randInt == 0)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 4.0f) - 4, transform.position.z);
        } 
        else if(randInt == 1)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 5.0f) - 4, transform.position.z);
        }
        else if(randInt == 2)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 6.0f) - 4, transform.position.z);
        }
    }
}
