﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchToMiniScene : MonoBehaviour
{
    private bool on_board;
	public GameObject player;
	public GameObject manager;
    void Start()
    {
        on_board = false;
    }
    void Update()
    {
        if(on_board==true)
		{
			if(Input.GetKeyUp(KeyCode.F))
			{
				//important values are saved in static class ManagerKeeper to re-use later.
				ManagerKeeper.Set_values(player.gameObject.GetComponent<Transform>().position,player.gameObject.GetComponent<CharController>().Return_number_of_lifes(),player.gameObject.GetComponent<CharController>().Return_number_of_cells(),player.gameObject.GetComponent<CharController>().Return_number_of_respawn_point());
				ManagerKeeper.Set_manager_script_info(manager.gameObject.GetComponent<ManagerScript>().Set_current_time());
				ManagerKeeper.Is_in_other_scene(true);
				SceneManager.LoadScene("Pac_Punk");
			}
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            on_board = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			on_board = false;
		}
	}
}
