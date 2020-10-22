using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalBox01 : MonoBehaviour
{
	private bool hit_the_player;

	public GameObject player;
	//public GameObject hook;
	void Start()
	{
		hit_the_player = false;
	}
	void Update()
	{
		if (hit_the_player == true)
		{
			player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
			hit_the_player = false;
			//Debug.Log("touched");
		/*	if (hook.gameObject.GetComponent<HookWithTheBox>().Get__nodes_id() > 3 && hook.gameObject.GetComponent<HookWithTheBox>().Get__nodes_id() < 6)
			{
				//Debug.Log("u_dead");
				
			}*/
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			hit_the_player = true;
			//Debug.Log("touched");
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			hit_the_player = false;
		}
	}
	public bool Return_if_hit_the_player()
	{
		return hit_the_player;
	}
}