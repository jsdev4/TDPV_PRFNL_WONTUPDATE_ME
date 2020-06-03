using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGround : MonoBehaviour
{
    private bool on_board;
    private Rigidbody rb;
    private Transform transform0;
    private Vector3 respawnpoint;
    private Vector3 displacement;
    private float delay;
    public float time_for_falling;
    private bool has_touched_the_trigger;
    void Start()
    {
        
        on_board = false;
        has_touched_the_trigger = false;
        delay = 0;

        rb = GetComponent<Rigidbody>();
        transform0 = GetComponent<Transform>();
        rb.isKinematic = true;
        respawnpoint = transform0.position;
        displacement = new Vector3(0, 0, 0.5f * Time.deltaTime);
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
            transform.position = respawnpoint;
            transform.rotation = Quaternion.Euler(-10, 0, 0);
            rb.isKinematic = true;
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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerForFalseGround"))
        {
            has_touched_the_trigger = false;
        }
    }
}
