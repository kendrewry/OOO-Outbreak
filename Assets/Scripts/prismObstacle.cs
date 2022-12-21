using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prismObstacle : MonoBehaviour
{
    bool reset = false;
    float resetDist = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        
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
                init.x = init.x + resetDist;
                transform.position = init;
                reset = false;
            }
            else
            {
                init.y = init.y + 3;
                resetDist = Random.Range(-3.0f, 3.0f);
                init.x = init.x - resetDist;
                transform.position = init;
                reset = true;
            }
            yield return waitTime;
        }
    }
}
