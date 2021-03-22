using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButtonFinal : MonoBehaviour
{
    private bool can_use;
    private bool going_move;
    public float max_time;
    private float delay_for_elevator;
    public GameObject player;
    public GameObject elevator;
    public GameObject text;
    void Start()
    {
        can_use = false;
        going_move = false;
    }
    void Update()
    {
        if (can_use == true && elevator.gameObject.GetComponent<ElevatorFinal>().Return_if_is_up() == false)
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
                    elevator.gameObject.GetComponent<ElevatorFinal>().Set_if_is_up(true);
                    delay_for_elevator = 0;
                    going_move = false;
                }
            }
        }
        if (can_use == true && elevator.gameObject.GetComponent<ElevatorFinal>().Return_if_on_board() == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                elevator.gameObject.GetComponent<ElevatorFinal>().Set_if_is_up(false);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can_use = true;
            text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can_use = false;
            text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(false);
        }
    }
}

