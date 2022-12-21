using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerProblem : MonoBehaviour
{
    public Text question;
    public GameObject answer;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        //Question UI
        question.transform.SetParent(canvas.transform);
        question.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("PROBLEM TRIGGERED");

        //Question UI
        question.enabled = true;
        question.text = "THIS IS A QUESTION";
        Vector3 temp = question.transform.position;
        temp.y += 150;
        question.transform.position = temp;

        //Answer UI
        //Answer1
        GameObject go = (GameObject)Instantiate(answer);
        Button myBtn = go.GetComponent<Button>();
        go.transform.SetParent(canvas.transform);
        myBtn.GetComponentInChildren<Text>().text = "my button text";
        Vector3 temp2 = temp;
        temp2.x -= 200;
        temp2.y -= 100;
        myBtn.transform.position = temp2;
        //Answer2
        GameObject go1 = (GameObject)Instantiate(answer);
        Button myBtn2 = go1.GetComponent<Button>();
        go1.transform.SetParent(canvas.transform);
        myBtn2.GetComponentInChildren<Text>().text = "my button text2";
        Vector3 temp3 = temp;
        temp3.y -= 100;
        myBtn2.transform.position = temp3;
        //answer3
        GameObject go2 = (GameObject)Instantiate(answer);
        Button myBtn3 = go2.GetComponent<Button>();
        go2.transform.SetParent(canvas.transform);
        myBtn3.GetComponentInChildren<Text>().text = "my button text3";
        Vector3 temp4 = temp;
        temp4.y -= 100;
        temp4.x += 200;
        myBtn3.transform.position = temp4;
    }
}
