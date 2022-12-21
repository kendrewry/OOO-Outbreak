using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prismObstacle : MonoBehaviour
{
    public float speed;
    public int randInt;
    // Start is called before the first frame update
    void Start()
    {
        randInt = Random.Range(0,2);
        speed = Random.Range(3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 3.0f) - 3.2f, transform.position.z);
    }
}
