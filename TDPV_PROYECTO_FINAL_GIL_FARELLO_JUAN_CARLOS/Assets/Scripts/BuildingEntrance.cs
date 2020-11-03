using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntrance : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public GameObject fader;
    private bool player_here;
    void Start()
    {
        player_here = false;
    }

 
    void Update()
    {
        //poner el fader antes de cambiar a otro escenario modificar el objecto publico player por fader
        if(player_here == true)
		{
            if (Input.GetKeyUp(KeyCode.F))
            {
                fader.SetActive(true);
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                ManagerKeeper.Is_ed102_entering_some_place(true);
               /* player.gameObject.GetComponent<Transform>().position = respawnPoint.gameObject.GetComponent<Transform>().position;
                player_here = false;*/
            }
            if(fader.gameObject.GetComponent<FaderScript>().Return_animation_complete()==true)
			{
                player.gameObject.GetComponent<Transform>().position = respawnPoint.gameObject.GetComponent<Transform>().position;
                player_here = false;
                ManagerKeeper.Is_ed102_entering_some_place(false);
                fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
                fader.gameObject.GetComponent<FaderScript>().Set_animation_complete(false);
               
            }
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            player_here = true;
		}
	}
    private void OnTriggerExit(Collider other)
	{
        if(other.CompareTag("Player"))
		{
            player_here = false;
		}
	}
}
