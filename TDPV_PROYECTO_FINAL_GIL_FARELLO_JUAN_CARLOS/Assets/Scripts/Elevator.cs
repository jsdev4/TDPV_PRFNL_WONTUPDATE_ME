using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private bool on_board;
    public float speed_up;
    public float speed_down;
    public bool is_up;
    public GameObject trigger;
    public GameObject trigger01;
    private bool has_stopped;
    public bool is_final_elevator;
    private Rigidbody rb;
    private Transform trnsfrm;
    void Start()
    {
       on_board = false;
        trnsfrm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 sizeVec = trigger.GetComponent<Collider>().bounds.size;
        Vector3 sizeVec01 = trigger01.GetComponent<Collider>().bounds.size;
        if (is_up == true)
        {
            if (trnsfrm.position.y <= trigger01.transform.position.y+sizeVec01.y/2)
            {
                rb.MovePosition(trnsfrm.position + trnsfrm.up * speed_up * Time.fixedDeltaTime);
            }
        }
        if(transform.position.y==trigger01.transform.position.y+sizeVec01.y/2)
        {
            rb.MovePosition(trnsfrm.position + trnsfrm.up * 0 * Time.fixedDeltaTime);
            is_up = true;
        }
        if (is_up == false)
        { 
            if (trnsfrm.position.y > trigger.transform.position.y+sizeVec.y/2&&has_stopped == false)
            {
                rb.MovePosition(trnsfrm.position - trnsfrm.up * speed_down * Time.fixedDeltaTime);
            }
            if (transform.position.y  == trigger.transform.position.y+sizeVec.y/4 )
            {
                rb.MovePosition(trnsfrm.position - trnsfrm.up * 0 * Time.fixedDeltaTime);
                is_up = false;
            }
            if (has_stopped == true )
            {
                rb.MovePosition(trnsfrm.position - trnsfrm.up * speed_down * Time.fixedDeltaTime);
            }  
        } 
    }
    public void Set_if_is_up(bool up)
    {
        is_up = up;
    }
    public bool Return_if_on_board()
    {
        return on_board;
    }
    public bool Return_if_is_up()
    {
        return is_up;
    }
    public void Set_if_stopped(bool stp)
    {
        has_stopped = stp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            on_board = true;   
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            on_board = false;
        }
    }
}

