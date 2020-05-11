using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForSplat : MonoBehaviour
{

    private bool splatted;
    private bool stop_elevator;
    public GameObject elevator;
    public GameObject player;
    private float timer;
    void Start()
    {
        timer = 0;
        stop_elevator = false;
        splatted = false;
    }
    void Update()
    {
        if(splatted==true&&elevator.gameObject.GetComponent<Elevator>().Return_if_is_up()==false)
        {
            elevator.gameObject.GetComponent<Elevator>().Set_if_stopped(true);
            player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
            splatted = false;
            stop_elevator = true;
        }
        if(stop_elevator==true)
        {
            timer += Time.deltaTime;
            if(timer>=5)
            {
                elevator.gameObject.GetComponent<Elevator>().Set_if_stopped(false);
                stop_elevator = false;
                timer = 0;
            }
           /* elevator.gameObject.GetComponent<Elevator>().Set_if_stopped(false);
            stop_elevator = false;*/
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            splatted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            splatted = false;
        }
    }
}
