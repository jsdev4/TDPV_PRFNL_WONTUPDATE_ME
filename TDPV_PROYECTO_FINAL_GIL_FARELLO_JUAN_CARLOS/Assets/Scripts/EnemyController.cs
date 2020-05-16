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
    private float delay_to_random_patrol;
    public float max_distance;
    public float min_distance;
    public Transform target;
    private Transform this_object;
    public GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        translation = new Vector3(1, 0, 0);
        translation_to_left = new Vector3(-1, 0, 0);
        this_object = GetComponent<Transform>();
        random_to_patrol = Random.Range(0, 2);
        Debug.Log(random_to_patrol);
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance<max_distance&&this_object.position.x<player.gameObject.GetComponent<Transform>().position.x)
        {
            if (distance > min_distance)
            {
                quad.gameObject.GetComponent<Animator>().Play("EnemyRunning");
                Vector3 dirToTarget = transform.position - player.transform.position;
                Vector3 newPos = transform.position - dirToTarget;
                rotation_sprite = new Vector3(1, 1, 1);
                transform.localScale = rotation_sprite;
                transform.position = Vector3.Lerp(transform.position, newPos, 0.02f);
            }
            else
            {
                //here the attack code!
                quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");
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
            }
            else
            {
                //here the attack code!
                quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");
            }
        }
     
        else
        {
            delay_to_random_patrol += Time.deltaTime;
            if (delay_to_random_patrol >= 3)
            {
                random_to_patrol = Random.Range(0, 2);
                delay_to_random_patrol = 0;
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
    }
    public void Set_direction_for_move(bool dir)
    {
        direction = dir;
    }
}
