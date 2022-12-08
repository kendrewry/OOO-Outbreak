using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrueTiles : MonoBehaviour
{

    public GameObject respawn;
    private bool status;


    // Start is called before the first frame update
    void Start()
    {
        status = true;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (status)
        {
            //Update Material of Correct Tile
            Material green = Resources.Load("GreenTile", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = green;

            //Initializations
            respawn = GameObject.FindGameObjectWithTag("Respawn");
            //Debug.Log(System.Convert.ToBoolean(respawn.GetComponent<RandomizeMap>().chance));
            // Debug.Log("stepped on Real");
            Vector3 parent = respawn.GetComponent<RandomizeMap>().currTile;
            Material red = Resources.Load("RedTile", typeof(Material)) as Material;
            float range1 = Random.Range(-(respawn.GetComponent<RandomizeMap>().range), respawn.GetComponent<RandomizeMap>().range);
            float range2 = Random.Range(-(respawn.GetComponent<RandomizeMap>().range), respawn.GetComponent<RandomizeMap>().range);

            //Plane 1 Creation, Position, Rotation
            GameObject plane1 = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane1.GetComponent<Renderer>().material = red;
            plane1.transform.position = new Vector3(parent.x - 3f, parent.y + range1, parent.z + 5f + respawn.GetComponent<RandomizeMap>().diff);
            plane1.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            //Plane 2 Creation, Position, Rotation
            GameObject plane2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane2.GetComponent<Renderer>().material = red;
            plane2.transform.position = new Vector3(parent.x + 3f, parent.y + range2, parent.z + 5f + respawn.GetComponent<RandomizeMap>().diff);
            plane2.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            //Box Colliders
            BoxCollider bc1 = plane1.AddComponent(typeof(BoxCollider)) as BoxCollider;
            //bc1.size = new Vector3(12f, 5f, 12f);
            bc1.isTrigger = true;

            BoxCollider bc2 = plane2.AddComponent(typeof(BoxCollider)) as BoxCollider;
            //bc2.size = new Vector3(12f, 5f, 12f);
            bc2.isTrigger = true;

            if (System.Convert.ToBoolean(respawn.GetComponent<RandomizeMap>().chance))
            {
                if (respawn.GetComponent<RandomizeMap>().numIter == 1) 
                {
                    plane2.AddComponent<WinningTilw>();
                }
                else
                {
                    plane2.AddComponent<TrueTiles>();
                }
                bc2.size = new Vector3(10f, 5f, 10f);
                plane1.AddComponent<FalseTiles>();
                bc1.size = new Vector3(12f, 5f, 12f);
                respawn.GetComponent<RandomizeMap>().currTile = plane2.transform.position;
                Debug.Log("Right");
            } 
            else 
            {
                if (respawn.GetComponent<RandomizeMap>().numIter == 1) 
                {
                    plane1.AddComponent<WinningTilw>();
                }
                else
                {
                    plane1.AddComponent<TrueTiles>();
                }
                bc1.size = new Vector3(10f, 5f, 10f);
                plane2.AddComponent<FalseTiles>();
                bc2.size = new Vector3(12f, 5f, 12f);
                respawn.GetComponent<RandomizeMap>().currTile = plane1.transform.position;
                Debug.Log("Left");
            }

            respawn.GetComponent<RandomizeMap>().numIter = respawn.GetComponent<RandomizeMap>().numIter - 1;
            respawn.GetComponent<RandomizeMap>().chance = Random.Range(0, 2);
            status = false;
        }
    }
}
