using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElevatorButton01 : MonoBehaviour
{
    private bool can_use;
    private bool going_move;
    public float max_time;
    private float delay_for_elevator;
    public GameObject elevator;
    public GameObject player;
    public GameObject text;
    private AudioSource button_sound;
    void Start()
    {
        can_use = false;
        going_move = false;
        button_sound = GetComponentInChildren<AudioSource>();
    }
    void FixedUpdate()
    {
        if (can_use == true &&elevator.gameObject.GetComponent<Elevator>().Return_if_is_up()==true)
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                button_sound.Play();
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                going_move = true;
            }
            if(going_move==true)
            {
                delay_for_elevator += Time.fixedDeltaTime;
                if (delay_for_elevator >= max_time)
                {
                    elevator.gameObject.GetComponent<Elevator>().Set_if_is_up(false);
                    delay_for_elevator = 0;
                    going_move = false;
                }
            }
        }
        if (can_use == true && elevator.gameObject.GetComponent<Elevator>().Return_if_on_board() == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                button_sound.Play();
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                going_move = true;
            }
            if (going_move == true)
            {
                delay_for_elevator += Time.fixedDeltaTime;
                if (delay_for_elevator >= max_time)
                {
                    elevator.gameObject.GetComponent<Elevator>().Set_if_is_up(false);
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

