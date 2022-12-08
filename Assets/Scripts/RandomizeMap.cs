using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMap : MonoBehaviour
{

    public int diff;
    public float range;
    public int numCount;
    public int numIter;
    public int chance;
    public Vector3 currTile;

    // Start is called before the first frame update
    void Start()
    {
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
        } 
        else 
        {
            plane1.AddComponent<TrueTiles>();
            bc1.size = new Vector3(10f, 5f, 10f);
            plane2.AddComponent<FalseTiles>();
            bc2.size = new Vector3(12f, 5f, 12f);
            currTile = new Vector3(-2.5f, 0f, 10f);
            Debug.Log("Left");
        }

        chance = Random.Range(0, 2);

    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
