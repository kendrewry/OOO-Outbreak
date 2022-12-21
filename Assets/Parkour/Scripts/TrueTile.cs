using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class TrueTiles : MonoBehaviour
{

    public GameObject player;
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

            respawn = GameObject.FindGameObjectWithTag("Respawn");
            string[] curr = respawn.GetComponent<RandomizeMap>().curr;
            float[] currAns = respawn.GetComponent<RandomizeMap>().currAns;
            // Text t = respawn.GetComponent<RandomizeMap>().powerup;
            Text question = respawn.GetComponent<RandomizeMap>().question;

            // FirstPersonController fps = GameObject.FindGameObjectWithTag("Player");
            // fps.GetComponent<FirstPersonController>().m_WalkSpeed = 5f;
            // fps.GetComponent<FirstPersonController>().m_JumpSpeed = 10f;
            // fps.GetComponent<FirstPersonController>().m_GravityMultiplier = 2f;
            // int power = Random.Range(0, 3);
            // if (power == 0) {
            //     fps.GetComponent<FirstPersonController>().m_WalkSpeed *= 2;
            //     t.text = "PowerUp: Speed";
            // }
            // else if (power == 1) {
            //     fps.GetComponent<FirstPersonController>().m_JumpSpeed *= 2;
            //     t.text = "PowerUp: JumpSpeed";
            // }
            // else if (power == 2) {
            //     fps.GetComponent<FirstPersonController>().m_GravityMultiplier /= 2;
            //     t.text = "PowerUp: Gravity";
            // }
            
            //Update Material of Correct Tile
            Material green = Resources.Load("GreenTile", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = green;

            //Initializations
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<FirstPersonController>().m_WalkSpeed += 0.2f;
            player.GetComponent<FirstPersonController>().m_JumpSpeed += 0.1f;
            // Debug.Log(System.Convert.ToBoolean(respawn.GetComponent<RandomizeMap>().chance));
            // Debug.Log("stepped on Real");
            Vector3 parent = respawn.GetComponent<RandomizeMap>().currTile;
            Material red = Resources.Load("RedTile", typeof(Material)) as Material;
            // float range1 = Random.Range(-(respawn.GetComponent<RandomizeMap>().range), respawn.GetComponent<RandomizeMap>().range);
            // float range2 = Random.Range(-(respawn.GetComponent<RandomizeMap>().range), respawn.GetComponent<RandomizeMap>().range);
            float range1 = 0.0f;
            float range2 = 0.0f;

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
                int qAns = Random.Range(0, 100);
                int q = Random.Range(0, curr.Length);
                question.text = curr[q] + "Jump Right if Answer is" + currAns[q] + "and Left if Answer is " + qAns;
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
                int qAns = Random.Range(0, 100);
                int q = Random.Range(0, curr.Length);
                question.text = curr[q] + "Jump Right if Answer is" + qAns + "and Left if Answer is " + currAns[q];
            }

            respawn.GetComponent<RandomizeMap>().numIter = respawn.GetComponent<RandomizeMap>().numIter - 1;
            respawn.GetComponent<RandomizeMap>().chance = Random.Range(0, 2);
            status = false;
        }
    }
}
