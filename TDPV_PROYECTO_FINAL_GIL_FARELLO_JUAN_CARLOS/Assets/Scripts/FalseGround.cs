﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGround : MonoBehaviour
{
    private bool on_board;
    private Rigidbody rb;
    private Transform transform0;
    private Vector3 respawnPoint;
    private Vector3 displacement;
    private float delay;
    private float delay_for_respawn;
    public float time_for_falling;
    private bool has_touched_the_trigger;
    public float speed_on_z_axis;
    void Start()
    {
        
        on_board = false;
        has_touched_the_trigger = false;
        delay = 0;
        delay_for_respawn = 0;
        rb = GetComponent<Rigidbody>();
        transform0 = GetComponent<Transform>();
        rb.isKinematic = true;
        respawnPoint = transform0.position;
        displacement = new Vector3(0, 0, speed_on_z_axis * Time.deltaTime);
    }
    void Update()
    {
        if(on_board==true)
        {
            delay += Time.deltaTime;
            if (delay > time_for_falling)
            {
                    rb.isKinematic =false;
                rb.transform.Translate(displacement);
            }
        }
        if(on_board==false)
        {
            delay = 0;
           
        }
        if(has_touched_the_trigger==true)
        {
            delay_for_respawn += Time.deltaTime;
            if (delay_for_respawn > 2)
            {
                transform.position = respawnPoint;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.isKinematic = true;
                delay_for_respawn = 0;
                has_touched_the_trigger = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            on_board = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            on_board = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerForFalseGround"))
        {
            has_touched_the_trigger = true;
        }
    }
    public void Reset_Object()
    {
        transform.position = respawnPoint;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.isKinematic = true;
        delay_for_respawn = 0;
        has_touched_the_trigger = false;
    }
}
