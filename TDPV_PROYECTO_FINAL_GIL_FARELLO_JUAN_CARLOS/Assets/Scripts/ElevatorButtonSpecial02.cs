using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonSpecial02 : MonoBehaviour
{
    private bool can_use;
    private bool going_move;
    public float max_time;
    private float delay_for_elevator;
    public GameObject player;
    public GameObject elevator;
    void Start()
    {
        can_use = false;
        going_move = false;
    }
    void Update()
    {
        if (can_use == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                going_move = true;
            }
            if(going_move==true)
            {
                delay_for_elevator += Time.deltaTime;
                if(delay_for_elevator>=max_time)
                {
                    elevator.gameObject.GetComponent<ElevatorSpecial>().Set_level(3);
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