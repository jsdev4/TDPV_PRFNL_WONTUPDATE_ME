using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTrigger : MonoBehaviour
{

    private bool player_is_here;
    public GameObject player;
    void Start()
    { 
        player_is_here = false;
    }
    void Update()
    {
        if(player_is_here==true)
        {
             player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
            player_is_here = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player_is_here = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player_is_here = false;
        }
    }
}
