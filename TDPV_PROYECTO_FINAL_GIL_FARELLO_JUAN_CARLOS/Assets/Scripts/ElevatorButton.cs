using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    private bool can_use;
    public GameObject elevator;
    public GameObject lights;

    void Start()
    {
      
        can_use = false;



        
    }
    void Update()
    {

        if (can_use==true&&elevator.gameObject.GetComponent<Elevator>().Return_if_is_up()==false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                elevator.gameObject.GetComponent<Elevator>().Set_if_is_up(true);
            }
        }
        if (can_use==true&&elevator.gameObject.GetComponent<Elevator>().Return_if_on_board()==false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                elevator.gameObject.GetComponent<Elevator>().Set_if_is_up(false);
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
        if(other.CompareTag("Player"))
        {
            can_use = false;
        }
    }
}
