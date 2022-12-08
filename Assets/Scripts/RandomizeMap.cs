using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMap : MonoBehaviour
{

    public int diff;
    public float range;
    public int numIter;
    public int chance;
    public Vector3 currTile;
    public GameObject fps;

    // Start is called before the first frame update
    void Start()
    {

        diff = 2;

        if (diff == 0)
        {
            numIter = 5;
            range = 0.4f;
        }
        else if (diff == 1)
        {
            numIter = 10;
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
        bc1.size = new Vector3(12f, 5f, 12f);
        bc1.isTrigger = true;

        BoxCollider bc2 = plane2.AddComponent(typeof(BoxCollider)) as BoxCollider;
        bc2.size = new Vector3(15f, 5f, 15f);
        bc2.isTrigger = true;

        chance = Random.Range(0, 2);
        //Debug.Log(System.Convert.ToBoolean(chance));

        if (System.Convert.ToBoolean(chance))
        {
            plane1.AddComponent<FalseTiles>();
            plane2.AddComponent<TrueTiles>();
            currTile = new Vector3(2.5f, 0f, 10f);
            Debug.Log("Right");
        } 
        else 
        {
            plane1.AddComponent<TrueTiles>();
            plane2.AddComponent<FalseTiles>();
            currTile = new Vector3(-2.5f, 0f, 10f);
            Debug.Log("Left");
        }

        chance = Random.Range(0, 2);

    }

    // Update is called once per frame
    void Update()
    {
        if (fps.transform.position.y <= -30f)
        {
            fps.transform.position = new Vector3(0f, 5f, 0f);
        }
    }
}
