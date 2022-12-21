using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerProblem : MonoBehaviour
{
    public Text question;
    public Text feedback;
    public GameObject answer;
    public GameObject canvas;
    public string[] beg = {"1  +  8  -  2  -  2", "1  +  9  +  1  +  9", "4  -  1  +  10  +  2", "6  +  3  -  6  -  2", "7  +  8  +  4  -  10", "1  +  6  -  5  +  4", "8  -  5  +  1  +  1", "3  +  4  +  8  +  8", "	5  +  1  +  4  -  3", "9  -  5  +  5  +  3", "6  +  3  +  3  +  5", "9  +  9  +  3  +  6"};
    public float[] begAns = {5, 20, 15, 1, 9, 6, 5, 23, 7, 12, 17, 27};
    public string[] med = {
        "24 - (19 - 13)",
        "29 + (8 + 6)",
        "(24 + 15) + 17",
        "(16 + 24) - 30",
        "(3 + 6) + 15",
        "28 + (19 - 3)",
        "6 + 2 + 15",
        "25 + (25 + 23)",
        "19 + 17 + 28",
        "27 + 27 + 6",
        "23 + (12 - 7)",
        "20 - 11 + 13"};
    public float[] medAns = {18f, 43f, 56f, 10f, 24f, 44f, 23f, 73f, 64f, 60f, 28f, 22f};
    public string[] hard = {"-1 + 1 * 5", "-9 / (10 - 8)", "-10 / (10 - 6)", "(-1 - 4) / 10", "(1 * 6) / 10", "(-6 * 1) / 10", "-2 - 8 - 2", "(-2 - 7) / -4", "(-4 / 2) - 4", "-8 - 8 * 3"};
    public float[] hardAns = {4, -4.5f, -2.5f, -0.5f, 0.6f, -0.6f, -12, 2.25f, -6, -32};

    private GameObject go;
    private Button myBtn;
    private GameObject go1;
    private Button myBtn2;
    private GameObject go2;
    private Button myBtn3;

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

    public string[] pickQuestion(int difficulty)
    {
        int q = Random.Range(0, beg.Length-1);
        if(difficulty == 0)
        {
            string[] ret = {beg[q], q.ToString()};
            return ret;
        } 
        else if(difficulty == 1)
        {
            string[] ret = {med[q], q.ToString()};
            return ret;
        }
        else
        {
            string[] ret = {hard[q], q.ToString()};
            return ret;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int difficulty = 0;

        //Question UI
        question.enabled = true;
        string[] ret = pickQuestion(difficulty);
        question.text = "Solve: " + ret[0];
        Vector3 temp = question.transform.position;

        //Answer UI
        //Answer1
        go = (GameObject)Instantiate(answer);
        myBtn = go.GetComponent<Button>();
        go.transform.SetParent(canvas.transform);
        myBtn.GetComponentInChildren<Text>().text = ret[1];
        Vector3 temp2 = temp;
        temp2.x -= 200;
        temp2.y -= 100;
        myBtn.transform.position = temp2;
        myBtn.onClick.AddListener(correct);

        //Answer2
        go1 = (GameObject)Instantiate(answer);
        myBtn2 = go1.GetComponent<Button>();
        go1.transform.SetParent(canvas.transform);
        myBtn2.GetComponentInChildren<Text>().text = ret[1] + 2;
        Vector3 temp3 = temp;
        temp3.y -= 100;
        myBtn2.transform.position = temp3;
        myBtn2.onClick.AddListener(incorrect);

        //answer3
        go2 = (GameObject)Instantiate(answer);
        myBtn3 = go2.GetComponent<Button>();
        go2.transform.SetParent(canvas.transform);
        myBtn3.GetComponentInChildren<Text>().text = (int.Parse(ret[1]) - 2).ToString();
        Vector3 temp4 = temp;
        temp4.y -= 100;
        temp4.x += 200;
        myBtn3.transform.position = temp4;
        myBtn3.onClick.AddListener(incorrect);

        void correct()
        {
            Destroy(go);
            Destroy(myBtn);
            Destroy(go1);
            Destroy(myBtn2);
            Destroy(go2);
            Destroy(myBtn3);
            question.text = "";
            feedback.text = "Correct!";
        }
        void incorrect()
        {
            Destroy(go);
            Destroy(myBtn);
            Destroy(go1);
            Destroy(myBtn2);
            Destroy(go2);
            Destroy(myBtn3);
            question.text = "";
            feedback.text = "Incorrect!";
        }
    }
}
