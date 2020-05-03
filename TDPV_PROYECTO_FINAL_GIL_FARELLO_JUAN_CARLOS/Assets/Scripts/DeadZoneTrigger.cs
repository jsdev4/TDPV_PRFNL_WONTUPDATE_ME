using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTrigger : MonoBehaviour
{

    private bool player_is_here;
    private bool npc_is_here;
    public GameObject player;
    public GameObject npc;
    void Start()
    {

        player_is_here = false;
        npc_is_here = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player_is_here==true)
        {
            player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
            player_is_here = false;
        }
        if(npc_is_here==true)
        {
            npc.gameObject.GetComponentInChildren<Animator>().enabled = true;
            npc.gameObject.GetComponentInChildren<Animator>().Play("NpcDying");
            npc.gameObject.GetComponent<NpcDying>().hit_the_ground();
            npc_is_here = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player_is_here = true;
        }
        if(other.gameObject.CompareTag("NpcOnDeadZone"))
        {
            npc_is_here = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player_is_here = false;
        }
        if(other.gameObject.CompareTag("NpcOnDeadZone"))
        {
            npc_is_here = false;
        }
    }
}
