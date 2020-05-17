using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool direction;
    private Rigidbody rb;
    public GameObject quad;
    private Vector3 translation;
    private Vector3 translation_to_left;

    private Vector3 rotation_sprite;
    private int random_to_patrol;
    private int numbers_of_hitted;
    private int number_of_cells;
    private float delay_to_random_patrol;
    public float max_distance;
    public float min_distance;
    public Transform target;
    private Transform this_object;
    public GameObject player;
    public GameObject light_gun;
    void Start()
    {
        numbers_of_hitted = 0;
        number_of_cells = 5;
        rb = GetComponent<Rigidbody>();
        translation = new Vector3(1, 0, 0);
        translation_to_left = new Vector3(-1, 0, 0);
        this_object = GetComponent<Transform>();
        Generate_random_number();
        Debug.Log(random_to_patrol);
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < max_distance && this_object.position.x < player.gameObject.GetComponent<Transform>().position.x)
        {
            if (distance > min_distance)
            {
                quad.gameObject.GetComponent<Animator>().Play("EnemyRunning");
                Vector3 dirToTarget = transform.position - player.transform.position;
                Vector3 newPos = transform.position - dirToTarget;
                rotation_sprite = new Vector3(1, 1, 1);
                transform.localScale = rotation_sprite;
                transform.position = Vector3.Lerp(transform.position, newPos, 0.02f);
                light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(false);
            }
            if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == true)
            {
                //here the attack code!
                quad.gameObject.GetComponent<Animator>().Play("EnemyAttacking");
               // light_gun.gameObject.GetComponent<LightPathFollower6>().CheckNode();
                light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(true);
                Increase_number_of_hits();
            }
            else if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == false)
            {
                
                quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");
               
                light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(false);
               
            }
        }
        else if (distance < max_distance && this_object.position.x > player.gameObject.GetComponent<Transform>().position.x)
        {


            if (distance > min_distance)
            {
                quad.gameObject.GetComponent<Animator>().Play("EnemyRunning");
                Vector3 dirToTarget = transform.position - player.transform.position;
                Vector3 newPos = transform.position - dirToTarget;
                rotation_sprite = new Vector3(-1, 1, 1);
                transform.localScale = rotation_sprite;
                transform.position = Vector3.Lerp(transform.position, newPos, 0.02f);
                light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(false);
            }
            if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == true)
            {
                //here the attack code!
                quad.gameObject.GetComponent<Animator>().Play("EnemyAttacking");
                light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(true);
                Increase_number_of_hits();
            }
            else if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == false)
            {

                quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");

                light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(false);

            }
        }
        else
        {
            delay_to_random_patrol += Time.deltaTime;
            if (delay_to_random_patrol >= 3)
            {
                Generate_random_number();

            }
            if (random_to_patrol == 1)
            {
                quad.gameObject.GetComponent<Animator>().Play("EnemyRunning");
                if (direction == true)
                {
                    rb.MovePosition(transform.position + translation * speed * Time.deltaTime);
                    rotation_sprite = new Vector3(1, 1, 1);
                    transform.localScale = rotation_sprite;
                }
                else
                {
                    rb.MovePosition(transform.position + translation_to_left * speed * Time.deltaTime);
                    rotation_sprite = new Vector3(-1, 1, 1);
                    transform.localScale = rotation_sprite;
                }
            }
            else
            {
                quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");
            }
        }
        if(numbers_of_hitted==100||numbers_of_hitted==200 || numbers_of_hitted == 300 || numbers_of_hitted == 400 || numbers_of_hitted == 500)
        {
            number_of_cells -= 1;
            Debug.Log(number_of_cells);
            if(number_of_cells==0)
            {
                Set_new_status();
            }
        }
    }


    public void Set_direction_for_move(bool dir)
    {
        direction = dir;
    }
    private void Increase_number_of_hits()
    {
        numbers_of_hitted++;
        // Debug.Log(numbers_of_hitted);
        light_gun.gameObject.GetComponent<LightPathFollower6>().Set_checkNode(true);
    }
    private void Set_new_status()
    {
        player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
        numbers_of_hitted = 0;
        number_of_cells = 5;
       
    }
    private void Generate_random_number()
    {
        random_to_patrol = Random.Range(0, 2);
        delay_to_random_patrol = 0;
    }
}
