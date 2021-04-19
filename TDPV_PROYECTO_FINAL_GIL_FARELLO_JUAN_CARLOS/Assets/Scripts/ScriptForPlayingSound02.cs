using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForPlayingSound02 : MonoBehaviour
{
    private AudioSource sound_to_play;
	public GameObject manager;
	private bool player_is_here;
    void Start()
    {
        sound_to_play = GetComponent<AudioSource>();
		player_is_here = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(manager.gameObject.GetComponent<ManagerScript>().Return_if_paused()==false)
		{
			sound_to_play.enabled = true;
			if (player_is_here == true)
			{
				sound_to_play.playOnAwake = true;
			}
		}
		else
		{
			sound_to_play.enabled = false;
			if (player_is_here == false)
			{
				sound_to_play.playOnAwake = false;
			}
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
           sound_to_play.Play();
			player_is_here = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			sound_to_play.Stop();
			player_is_here = false;
		}
	}
}
