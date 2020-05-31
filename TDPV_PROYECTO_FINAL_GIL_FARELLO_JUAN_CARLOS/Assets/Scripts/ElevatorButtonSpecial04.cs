using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonSpecial04 : MonoBehaviour
{
    private bool can_use;
    private bool going_move;
    public float max_time;
    private float delay_for_elevator;
    public GameObject elevator;
    public GameObject player;
    void Start()
    {
        can_use = false;
        going_move = false;
    }
    void Update()
    {
        if (can_use == true&&elevator.gameObject.GetComponent<ElevatorSpecial>().Return_if_is_up()==true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                going_move = true;
            }
            if(going_move==true)
            {
                delay_for_elevator += Time.deltaTime;
                if(delay_for_elevator>=max_time)
                {
                    elevator.gameObject.GetComponent<ElevatorSpecial>().Set_if_is_up(false);
                    delay_for_elevator = 0;
                    going_move = false;
                }
            }
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can_use = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can_use = false;
        }
    }
}