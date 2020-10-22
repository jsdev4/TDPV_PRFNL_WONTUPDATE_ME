using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocatePlayerOnLevel : MonoBehaviour
{
    private bool on_trigger;
    private bool moving_it;
    private float firstPosZ;
    public GameObject player;
    void Start()
    {
        on_trigger = false;
        firstPosZ = player.gameObject.GetComponent<Transform>().position.z;
        moving_it = false;
    }

    
    void Update()
    {
        Vector3 fixedPos = new Vector3(player.gameObject.GetComponent<Transform>().position.x, player.gameObject.GetComponent<Transform>().position.y, firstPosZ);
        if (on_trigger==true)
		{
            
            moving_it = true;
            on_trigger = false;
            
		}
        if(moving_it==true)
		{
            player.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;
            if (player.gameObject.GetComponent<Transform>().position.z > 0.4f)
            {
                player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * .4f, ForceMode.Impulse);
            }
            if (player.gameObject.GetComponent<Transform>().position.z<=0.4f)
            {
               
                player.gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(player.gameObject.GetComponent<Transform>().position.x, player.gameObject.GetComponent<Transform>().position.y, firstPosZ));
                player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                player.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
                player.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                moving_it = false;
            }
        }
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
           // Debug.Log("touched the trigger");
            on_trigger = true;
		}
	}
}
//revised
