using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForRespawnOnSide : MonoBehaviour
{
    public GameObject player;
    public GameObject point_to_respawn;
    private bool player_is_here;
    public bool trigger_side;
    
    void Start()
    {
       // trnsfrm = GetComponent<Transform>();
    }
    void Update()
    {
        if (trigger_side ==false)
        {
            if (player_is_here == true)
            {
              
                player.gameObject.GetComponent<Transform>().position = new Vector3(point_to_respawn.gameObject.GetComponent<Transform>().position.x - 3f, player.gameObject.GetComponent<Transform>().position.y, player.gameObject.GetComponent<Transform>().position.z);

                player_is_here = false;
            }
        }
        if (trigger_side ==true)
        {
            if (player_is_here == true)
            {

                player.gameObject.GetComponent<Transform>().position = new Vector3(point_to_respawn.gameObject.GetComponent<Transform>().position.x + 3f, player.gameObject.GetComponent<Transform>().position.y, player.gameObject.GetComponent<Transform>().position.z);

                player_is_here = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
		{
            Debug.Log("you are here");
            player_is_here = true;
		}
	}
}
