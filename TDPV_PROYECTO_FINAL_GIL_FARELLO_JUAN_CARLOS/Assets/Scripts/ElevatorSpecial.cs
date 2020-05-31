using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSpecial : MonoBehaviour
{
    private bool on_board;
    public float speed_up;
    public float speed_down;
    public bool is_up;
    public GameObject trigger;
    public GameObject trigger01;
    public GameObject trigger02;
    public GameObject trigger03;
    public GameObject trigger04;

    private int level;

    private bool has_stopped;
    void Start()
    {
       
        level = 0;
        is_up = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sizeVec = trigger.GetComponent<Collider>().bounds.size;
        
        if (is_up == true)
        {
            if (level == 1)
            {

                if (transform.position.y <= (trigger01.transform.position.y))
                {
                    transform.Translate(Vector3.up * speed_up * Time.deltaTime);
                
                }
                if (transform.position.y == (trigger01.transform.position.y))
                {
                      transform.Translate(Vector3.up * 0 * Time.deltaTime);
                   
                }

            }
            if (level == 2)
            {

                if (transform.position.y <= (trigger02.transform.position.y))
                {
                    transform.Translate(Vector3.up * speed_up * Time.deltaTime);

                }
                if (transform.position.y == (trigger02.transform.position.y))
                {
                    transform.Translate(Vector3.up * 0 * Time.deltaTime);

                }
            }
            if (level == 3)
            {

                if (transform.position.y <= trigger03.transform.position.y)
                {
                    transform.Translate(Vector3.up * speed_up * Time.deltaTime);
                }
                if (transform.position.y == trigger03.transform.position.y)
                {
                    transform.Translate(Vector3.up * 0 * Time.deltaTime);

                }
            }
            if (level == 4)
            {
                //  is_up = true;
                if (transform.position.y <= trigger04.transform.position.y)
                {
                    transform.Translate(Vector3.up * speed_up * Time.deltaTime);
                }
                if (transform.position.y == trigger04.transform.position.y)
                {
                    transform.Translate(Vector3.up * 0 * Time.deltaTime);

                }
            }
            if(level==5)
            {
              
            }
   
        }
       if (is_up==false)
       {
            if (transform.position.y > trigger.transform.position.y&&transform.position.y>trigger.transform.position.y+sizeVec.y)
            {
                if (has_stopped == false)
                {
                    transform.Translate(Vector3.down * speed_down * Time.deltaTime);
                }
            }

            if (transform.position.y == trigger.transform.position.y+sizeVec.y)
            {

                transform.Translate(Vector3.down * 0 * Time.deltaTime);
                level = 0;

            }
            if (has_stopped == true)
            {
                transform.Translate(Vector3.down * 0 * Time.deltaTime);
            }
           

        }
    }
    public void Set_level(int lvl)
    {
        level = lvl;
    }
    public int Return_level()
    {
        return level;
    }
    public void Set_if_is_up(bool up)
    {
        is_up = up;
    }
    public bool Return_if_is_up()
    {
        return is_up;
    }
    public bool Return_if_on_board()
    {
        return on_board;
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