using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntrance : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
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
                player.gameObject.GetComponent<Transform>().position = respawnPoint.gameObject.GetComponent<Transform>().position;
                player_here = false;
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
