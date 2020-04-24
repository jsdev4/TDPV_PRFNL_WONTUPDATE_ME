using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonSpecial01 : MonoBehaviour
{
    private bool can_use;
    public GameObject elevator;
    void Start()
    {
        can_use = false;
    }

    void Update()
    {
        if (can_use == true )
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                elevator.gameObject.GetComponent<ElevatorSpecial>().Set_level(2);
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
