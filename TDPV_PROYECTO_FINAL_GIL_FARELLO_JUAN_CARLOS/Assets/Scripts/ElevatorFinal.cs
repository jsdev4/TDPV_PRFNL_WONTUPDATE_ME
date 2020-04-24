using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorFinal : MonoBehaviour
{

    private bool on_board;
    private float speed;
    public bool is_up;
    public GameObject trigger;
    public GameObject trigger01;
    public GameObject no_fall_box;

    private bool has_stopped;
    void Start()
    {
        on_board = false;
        speed = 1;
        has_stopped = false;
    }
    void Update()
    {
        Vector3 sizeVec = trigger.GetComponent<Collider>().bounds.size;
        if (is_up == true)
        {
            if (transform.position.y <= (trigger01.transform.position.y))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                no_fall_box.gameObject.GetComponent<BoxCollider>().enabled = true;

            }
        }
        if (transform.position.y == trigger01.transform.position.y)
        {
            transform.Translate(Vector3.up * 0 * Time.deltaTime);
            is_up = true;
        }

        if (is_up == false)
        {
            if (transform.position.y > trigger.transform.position.y && transform.position.y > trigger.transform.position.y + sizeVec.y && has_stopped == false)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            if (transform.position.y == trigger.transform.position.y + sizeVec.y)
            {
                transform.Translate(Vector3.down * 0 * Time.deltaTime);
                is_up = false;
            }
            if (has_stopped == true)
            {
                transform.Translate(Vector3.down * 0 * Time.deltaTime);
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