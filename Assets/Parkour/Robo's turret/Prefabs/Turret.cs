using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Turret : MonoBehaviour
{
    private float shooting_delay;
    private GameObject projectile_template;
    private Vector3 direction_from_turret_to_player;
    private Vector3 shooting_direction;
    private Vector3 projectile_starting_pos;
    private float projectile_velocity;
    private bool player_is_accessible;

    // Start is called before the first frame update
    void Start()
    {
        projectile_template = (GameObject)Resources.Load("Dodgeball/Prefab/Dodgeball", typeof(GameObject));  // projectile prefab
        if (projectile_template == null)
            Debug.LogError("Error: could not find the dodgeball in the project!");
        shooting_delay = 1.0f;  
        projectile_velocity = 5.0f;
        direction_from_turret_to_player = new Vector3(0.0f, 0.0f, 0.0f);
        projectile_starting_pos = new Vector3(0.0f, 0.0f, 0.0f);
        player_is_accessible = false;
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject character = player.transform.GetChild(0).gameObject;

        if (player == null)
            Debug.LogError("Error: could not find the game character 'Player' in the scene");
        // Vector3 claire_centroid = claire.GetComponent<CapsuleCollider>().bounds.center;
        Vector3 player_centroid = character.GetComponent<CapsuleCollider>().bounds.center;
        Vector3 turret_centroid = GetComponent<Collider>().bounds.center;
        direction_from_turret_to_player = player_centroid - turret_centroid;
        direction_from_turret_to_player.Normalize();

        RaycastHit hit;
        if (Physics.Raycast( turret_centroid, direction_from_turret_to_player, out hit, Mathf.Infinity))
        {
            Debug.Log("hi");
            if (hit.collider.gameObject == character)
            {
                Debug.Log("hello");
            //     ////////////////////////////////////////////////
            //     // WRITE CODE HERE:
            //     // implement deflection shooting
                shooting_direction = direction_from_turret_to_player; // this is a very simple heuristic for shooting, replace it
            //     ////////////////////////////////////////////////

            //     //Iterative approach


                shooting_direction = player.transform.position;
                Vector3 last_shooting_direction;
                float delta_pos = Mathf.Infinity;
                while(delta_pos > 0.01f){
                    float distance = Vector3.Distance(shooting_direction, projectile_starting_pos) - 1.1f;
                    float look_ahead_time = distance / projectile_velocity;
                    last_shooting_direction = shooting_direction;
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                        shooting_direction = player.transform.position + look_ahead_time * player.GetComponent<FirstPersonController>().m_WalkSpeed * player.GetComponent<FirstPersonController>().m_MovementDirection;
                    }
                    else {
                        shooting_direction = player.transform.position;
                    }
                    delta_pos = Vector3.Distance(shooting_direction, last_shooting_direction);
                }
                shooting_direction = shooting_direction - transform.position;
                shooting_direction.Normalize();



                float angle_to_rotate_turret = Mathf.Rad2Deg * Mathf.Atan2(shooting_direction.x, shooting_direction.z);
                transform.eulerAngles = new Vector3(0.0f, angle_to_rotate_turret, 0.0f);
                Vector3 current_turret_direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y), 1.1f, Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y));
                projectile_starting_pos = transform.position + 1.1f * current_turret_direction;  // estimated position of the turret's front of the cannon
                player_is_accessible = true;
            }
            else
                player_is_accessible = false;            
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {            
            if (player_is_accessible)
            {
                GameObject new_object = Instantiate(projectile_template, projectile_starting_pos, Quaternion.identity);
                new_object.GetComponent<Dodgeball>().direction = shooting_direction;
                new_object.GetComponent<Dodgeball>().velocity = projectile_velocity;
                new_object.GetComponent<Dodgeball>().birth_time = Time.time;
                new_object.GetComponent<Dodgeball>().birth_turret = transform.gameObject;
            }
            yield return new WaitForSeconds(shooting_delay); // next shot will be shot after this delay
        }
    }
}
