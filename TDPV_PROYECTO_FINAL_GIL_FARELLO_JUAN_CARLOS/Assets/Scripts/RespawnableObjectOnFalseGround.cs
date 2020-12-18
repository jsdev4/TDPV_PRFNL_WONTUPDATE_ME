using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableObjectOnFalseGround : MonoBehaviour
{
    private bool on_board;
	private bool has_touched_the_trigger;
	private float delay;
	private float delay_for_respawn;
	public float time_for_falling;
	private Quaternion original_rotation;
	private Vector3 respawnPoint;
	private Transform transform0;
	//private Rigidbody rb;
	public GameObject false_ground;
    void Start()
    {
		//rb = GetComponent<Rigidbody>();
		delay = 0;
		delay_for_respawn = 0;
        on_board = false;
		has_touched_the_trigger = false;
		respawnPoint = GetComponent<Transform>().position;
		transform0 = GetComponent<Transform>();
		original_rotation = transform0.rotation;
	}
    void Update()
    {
        if(on_board==true)
		{
			delay += Time.deltaTime;
			if (delay > time_for_falling)
			{
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
				Reset_Object();
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
	public void Reset_Object()
	{
		transform.position = respawnPoint;
		transform.rotation = original_rotation; 
		delay_for_respawn = 0;
		has_touched_the_trigger = false;
	}
}
