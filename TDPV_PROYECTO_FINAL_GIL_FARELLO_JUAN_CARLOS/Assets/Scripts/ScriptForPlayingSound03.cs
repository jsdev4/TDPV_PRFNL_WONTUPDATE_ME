using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForPlayingSound03 : MonoBehaviour
{
    public bool is_the_mute_trigger;
    private bool player_is_here;
    private bool player_is_finally_here;
    public GameObject manager;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(manager.gameObject.GetComponent<ManagerScript>().Return_if_paused()==false&&is_the_mute_trigger==false)
		{
            if(player_is_here==true)
			{
                manager.gameObject.GetComponent<ManagerScript>().Set_volume_down(false);
            }
		}
        if (manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false && is_the_mute_trigger == true)
        {
            if(player_is_finally_here==true)
			{
                manager.gameObject.GetComponent<ManagerScript>().Set_volume_down(true);
			}
        }
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            player_is_here = true;
            player_is_finally_here = true;
		}
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_is_here = false;
        }
    }
}
