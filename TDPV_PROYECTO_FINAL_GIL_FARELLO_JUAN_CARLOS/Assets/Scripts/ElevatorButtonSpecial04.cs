using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonSpecial04 : MonoBehaviour
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
        if (can_use == true&&elevator.gameObject.GetComponent<ElevatorSpecial>().Return_if_is_up()==true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                elevator.gameObject.GetComponent<ElevatorSpecial>().Set_if_is_up(false);
             //   elevator.gameObject.GetComponent<ElevatorSpecial>().Set_level(5);
            
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