using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableObjectOnFalseGround : MonoBehaviour
{
    private bool on_board;
	private bool has_touched_the_trigger;
	private float delay;
	private float delay_for_respawn;
	private Vector3 respawnPoint;
	private Rigidbody rb;
	public GameObject false_ground;
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		delay = 0;
		delay_for_respawn = 0;
        on_board = false;
		has_touched_the_trigger = false;
		respawnPoint = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(on_board==true)
		{
			delay += Time.deltaTime;
			if (delay > 2)
			{
				rb.isKinematic = false;
				false_ground.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			}
		}
		if(on_board==false)
		{
			delay = 0;
		}
		if(has_touched_the_trigger==true)
		{
			delay_for_respawn += Time.deltaTime;
			if(delay_for_respawn>2)
			{
				transform.position = respawnPoint;
				transform.rotation = Quaternion.Euler(0, 0, 0);
				false_ground.gameObject.GetComponent<FalseGround>().Reset_Object();
				rb.isKinematic = true;
				delay_for_respawn = 0;
				has_touched_the_trigger = false;
			}

		}
    }
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
            on_board = true;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
			on_board = false;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("TriggerForFalseGround"))
		{
			has_touched_the_trigger = true;
		}
	}
}
