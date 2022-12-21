using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int getRand()
    {
        return Random.Range(1,2);
    }

    private IEnumerator move()
    {
        WaitForSeconds waitTime = new WaitForSeconds(Random.Range(0.5f,3.0f));
        while (true)
        {
            Vector3 init = transform.position;
            if(reset)
            {
                init.y = init.y - 3;
                transform.position = init;
                reset = false;
            }
            else
            {
                init.y = init.y + 3;
                transform.position = init;
                reset = true;
            }
            yield return waitTime;
        }
    }
}
