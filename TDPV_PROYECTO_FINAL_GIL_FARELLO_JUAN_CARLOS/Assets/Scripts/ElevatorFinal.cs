using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorFinal : MonoBehaviour
{

    private bool on_board;
    public float speed;
    public bool is_up;
    public GameObject trigger;
    public GameObject trigger01;
    public GameObject[] no_fall_box;
    private Rigidbody rb;
    private Transform trnsfrm;
    private bool has_stopped;
    void Start()
    {
        on_board = false;
        has_stopped = false;
        trnsfrm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 sizeVec = trigger.GetComponent<Collider>().bounds.size;
        if (is_up == true)
        {
            if (transform.position.y <= (trigger01.transform.position.y))
            {
                rb.MovePosition(trnsfrm.position + trnsfrm.up * speed * Time.fixedDeltaTime);
                for (int i = 0; i < 3; i++)
                {
                    no_fall_box[i].gameObject.GetComponent<BoxCollider>().enabled = true;
                }

            }
        }
        if (transform.position.y == trigger01.transform.position.y)
        {
            rb.MovePosition(trnsfrm.position + trnsfrm.up * 0 * Time.fixedDeltaTime);
            is_up = true;
        }

        if (is_up == false)
        {
            if (transform.position.y > trigger.transform.position.y && transform.position.y > trigger.transform.position.y + sizeVec.y && has_stopped == false)
            {
                rb.MovePosition(trnsfrm.position- trnsfrm.up * speed * Time.fixedDeltaTime);
            }

            if (transform.position.y == trigger.transform.position.y + sizeVec.y)
            {
                rb.MovePosition(trnsfrm.position - trnsfrm.up * 0 * Time.fixedDeltaTime);
                is_up = false;
            }
            if (has_stopped == true)
            {
                rb.MovePosition(trnsfrm.position - trnsfrm.up * 0 * Time.fixedDeltaTime);
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