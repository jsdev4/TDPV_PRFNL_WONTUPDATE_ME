﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemy_difficulty;
    public float speed;
    public float speed_when_spots_player;
    public bool direction;
    private bool can_attack;

    private Rigidbody rb;
    public GameObject quad;
    private Vector3 translation;
    private Vector3 translation_to_left;
    private Vector3 rotation_sprite;
    private int random_to_patrol;
    private int numbers_of_hitted;

    private float delay_to_random_patrol;
    public float max_distance;
    public float min_distance;

    public Transform target;
    private Transform this_object;
    public GameObject player;
    public GameObject light_gun;
    //
    public GameObject[] PathNode;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector3 startPosition;
    private float delay;
    public float max_time_to_reset;
    private bool check_node;
    void Start()
    {
        can_attack = true;
        numbers_of_hitted = 0;
        rb = GetComponent<Rigidbody>();
        translation = new Vector3(1, 0, 0);
        translation_to_left = new Vector3(-1, 0, 0);
        this_object = GetComponent<Transform>();
        Generate_random_number();
        //Debug.Log(random_to_patrol);
        delay = 0;
        Timer = 0;
        startPosition =light_gun.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }
    public void CheckNode()
    {
        Timer = 0;
        startPosition = light_gun.transform.localPosition;
        CurrentPositionHolder = PathNode[CurrentNode].transform.localPosition;
        light_gun.gameObject.GetComponent<Light>().enabled = true;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (can_attack == true)
        {
            if (distance < max_distance && this_object.position.x < player.gameObject.GetComponent<Transform>().position.x)
            {
                if (distance > min_distance)
                {
                    quad.gameObject.GetComponent<Animator>().Play("EnemyRunning");
                    Vector3 dirToTarget = transform.position - player.transform.position;
                    Vector3 newPos = transform.position - dirToTarget;
                    rotation_sprite = new Vector3(1, 1, 1);
                    transform.localScale = rotation_sprite;
                    rb.MovePosition( Vector3.Lerp(transform.position, newPos, speed_when_spots_player * Time.deltaTime));
                    Light_slider(false);
                }
                if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == true)
                {
                    quad.gameObject.GetComponent<Animator>().Play("EnemyAttacking");
                    Light_slider(true);
                    Increase_number_of_hits();
                }
                else if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == false)
                {
                    quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");
                    Light_slider(false);
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
                    rb.MovePosition(Vector3.Lerp(transform.position, newPos, speed_when_spots_player * Time.deltaTime));
                    Light_slider(false);
                }
                if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == true)
                {
                    quad.gameObject.GetComponent<Animator>().Play("EnemyAttacking");
                    Light_slider(true);
                    Increase_number_of_hits();
                }
                else if (distance < min_distance && player.gameObject.GetComponent<CharController>().Player_is_alive() == false)
                {
                    quad.gameObject.GetComponent<Animator>().Play("EnemyIdle");
                    Light_slider(false);
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
            
            if (enemy_difficulty==0)
            {
                if (numbers_of_hitted == 100 || numbers_of_hitted == 200 || numbers_of_hitted == 300 || numbers_of_hitted == 400 || numbers_of_hitted == 500)
                {
                    player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                    if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() == 0)
                    {
                        Set_new_status();
                    }
                }
            }
            if (enemy_difficulty == 1)
            { 
                if (numbers_of_hitted == 5 || numbers_of_hitted == 10 || numbers_of_hitted == 15 || numbers_of_hitted == 20 || numbers_of_hitted == 25)
                {
                    player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                    if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() == 0)
                    {
                        Set_new_status();
                    }
                }
            }
        }
    }
    public void Set_if_can_attack(bool attack_player)
    {
       can_attack=attack_player;
    }

    public void Set_direction_for_move(bool dir)
    {
        direction = dir;
    }
    private void Increase_number_of_hits()
    {
        numbers_of_hitted++;
        // Debug.Log(numbers_of_hitted);
    }
    private void Set_new_status()
    {
        player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
        numbers_of_hitted = 0;
    }
    private void Generate_random_number()
    {
        random_to_patrol = Random.Range(0, 2);
        delay_to_random_patrol = 0;
    }
    private void Light_slider(bool chck)
    {
        Timer += Time.deltaTime * MoveSpeed;
        check_node = chck;
        if (light_gun.transform.localPosition != CurrentPositionHolder)
        {
           light_gun.transform.localPosition = Vector3.Lerp(startPosition, CurrentPositionHolder, 1 * Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
                if (CurrentNode == 0)
                {
                    light_gun.gameObject.GetComponent<Light>().enabled = false;
                }
            }
            if (CurrentNode == PathNode.Length - 1)
            {
                delay += Time.deltaTime;
                if (delay >= max_time_to_reset)
                {
                    CurrentNode = -1;
                    delay = 0;
                }
            }
        }
        if (check_node == true)
        {
            light_gun.gameObject.GetComponent<Light>().enabled = true;
        }
        else
        {
            light_gun.gameObject.GetComponent<Light>().enabled = false;
        }
    }
}