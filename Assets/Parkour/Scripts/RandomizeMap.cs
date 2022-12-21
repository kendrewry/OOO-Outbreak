using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeMap : MonoBehaviour
{
    public Text question;
    public Text powerup;
    public int diff;
    public float range;
    public int numCount;
    public int numIter;
    public int chance;
    public Vector3 currTile;
    public int difficulty = 1;


    public string[] curr;
    public float[] currAns;

    public string[] beg = {"1  +  8  -  2  -  2", "1  +  9  +  1  +  9", "4  -  1  +  10  +  2", "6  +  3  -  6  -  2", "7  +  8  +  4  -  10", "1  +  6  -  5  +  4", "8  -  5  +  1  +  1", "3  +  4  +  8  +  8", "    5  +  1  +  4  -  3", "9  -  5  +  5  +  3", "6  +  3  +  3  +  5", "9  +  9  +  3  +  6"};
    public float[] begAns = {5, 20, 15, 1, 9, 6, 5, 23, 7, 12, 17, 27};

    public string[] med = new string[]{
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

    public float[] medAns = new float[]{18f, 43f, 56f, 10f, 24f, 44f, 23f, 73f, 64f, 60f, 28f, 22f};

    public string[] hard = {"-1 + 1 * 5", "-9 / (10 - 8)", "-10 / (10 - 6)", "(-1 - 4) / 10", "(1 * 6) / 10", "(-6 * 1) / 10", "-2 - 8 - 2", "(-2 - 7) / -4", "(-4 / 2) - 4", "-8 - 8 * 3"};
    public float[] hardAns = {4, -4.5f, -2.5f, -0.5f, 0.6f, -0.6f, -12, 2.25f, -6, -32};


    // Start is called before the first frame update
    void Start()
    {
        powerup.text = "";
        if (difficulty == 0) {
            curr = beg;
            currAns = begAns;
        }
        else if (difficulty == 1) {
            curr = med;
            currAns = medAns;
        }
        else {
            curr = hard;
            currAns = hardAns;
        }

        numCount = 1;

        diff = 2;

        if (diff == 0)
        {
            numIter = 15;
            range = 0.4f;
        }
        else if (diff == 1)
        {
            numIter = 15;
            range = 0.8f;
        }
        else
        {
            numIter = 15;
            range = 1.2f;
        }

        Material red = Resources.Load("RedTile", typeof(Material)) as Material;

        //Plane 1 Creation, Position, Rotation
        GameObject plane1 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane1.GetComponent<Renderer>().material = red;
        plane1.transform.position = new Vector3(-2.5f, 0f, 10f);
        plane1.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        //Plane 2 Creation, Position, Rotation
        GameObject plane2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane2.GetComponent<Renderer>().material = red;
        plane2.transform.position = new Vector3(2.5f, 0f, 10f);
        plane2.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        //Box Colliders
        BoxCollider bc1 = plane1.AddComponent(typeof(BoxCollider)) as BoxCollider;
        // bc1.size = new Vector3(12f, 5f, 12f);
        bc1.isTrigger = true;

        BoxCollider bc2 = plane2.AddComponent(typeof(BoxCollider)) as BoxCollider;
        // bc2.size = new Vector3(12f, 5f, 12f);
        bc2.isTrigger = true;

        chance = Random.Range(0, 2);
        //Debug.Log(System.Convert.ToBoolean(chance));

        if (System.Convert.ToBoolean(chance))
        {
            plane1.AddComponent<FalseTiles>();
            bc1.size = new Vector3(12f, 5f, 12f);
            plane2.AddComponent<TrueTiles>();
            bc2.size = new Vector3(10f, 5f, 10f);
            currTile = new Vector3(2.5f, 0f, 10f);
            Debug.Log("Right");
            int qAns = Random.Range(-2, 3);
            int q = Random.Range(0, curr.Length);
            question.text = curr[q] + "Jump Right if Answer is" + currAns[q] + "and Left if Answer is " + currAns[q] + (float)qAns;
        } 
        else 
        {
            plane1.AddComponent<TrueTiles>();
            bc1.size = new Vector3(10f, 5f, 10f);
            plane2.AddComponent<FalseTiles>();
            bc2.size = new Vector3(12f, 5f, 12f);
            currTile = new Vector3(-2.5f, 0f, 10f);
            Debug.Log("Left");
            int qAns = Random.Range(0, 100);
            int q = Random.Range(0, curr.Length);
            question.text = curr[q] + "Jump Right if Answer is" + currAns[q] + qAns.ToString() + "and Left if Answer is " + currAns[q];
        }

        chance = Random.Range(0, 2);

    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
