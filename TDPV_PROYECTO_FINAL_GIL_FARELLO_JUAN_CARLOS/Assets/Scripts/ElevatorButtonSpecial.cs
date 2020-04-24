using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonSpecial : MonoBehaviour
{
    private bool can_use;
    // private bool is_up;
    public GameObject elevator;
    void Start()
    {
        can_use = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_use == true && elevator.gameObject.GetComponent<ElevatorSpecial>().Return_if_is_up() == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                elevator.gameObject.GetComponent<ElevatorSpecial>().Set_if_is_up(true);
                elevator.gameObject.GetComponent<ElevatorSpecial>().Set_level(1);
             
            }
        }
       
        if (can_use == true && elevator.gameObject.GetComponent<ElevatorSpecial>().Return_if_on_board() == false)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                elevator.gameObject.GetComponent<ElevatorSpecial>().Set_if_is_up(false);
                elevator.gameObject.GetComponent<ElevatorSpecial>().Set_level(0);
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
