using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToFinalPart : MonoBehaviour
{
    private bool on_the_trigger;
    public GameObject fader;
    public GameObject player;
    public GameObject respawn_point;
    void Start()
    {
        on_the_trigger = false;
    }

    
    void Update()
    {
        if(on_the_trigger==true)
		{
            if(Input.GetKeyUp(KeyCode.F))
			{
                fader.SetActive(true);
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                
			}
            if (fader.gameObject.GetComponent<FaderScript>().Return_animation_complete() == true)
            {
                player.gameObject.GetComponent<Transform>().position = respawn_point.gameObject.GetComponent<Transform>().position;
            }
        }
       
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            on_the_trigger = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            on_the_trigger = false;
		}
	}
}
