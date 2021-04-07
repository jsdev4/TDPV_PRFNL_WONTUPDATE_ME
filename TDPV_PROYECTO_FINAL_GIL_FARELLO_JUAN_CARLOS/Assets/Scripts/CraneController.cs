using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    private bool direction;
    private bool splatted_something;
    public float acceleration;
    public float delay_to_restart;
    public float wheel_rotation;
    private float current_speed;
    private float timer;
    private Rigidbody rb;
    private Vector3 translation;
    private Vector3 translation_to_left;
    private bool delay_the_boolean;
    public GameObject[] wheels;
    public GameObject manager;
    private AudioSource diesel_sound;
    void Start()
    {
        splatted_something = false;
        current_speed = 0;
        direction = true;
        delay_the_boolean = false;
        rb = GetComponent<Rigidbody>();
         translation = new Vector3(1, 0, 0);
        translation_to_left = new Vector3(-1, 0, 0);
        diesel_sound = GetComponent<AudioSource>();
        diesel_sound.Play();
    }
    void Update()
    {
        if (manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false)
        {
            diesel_sound.enabled = true;
            if (splatted_something == false)
            {
                if (delay_the_boolean == true)
                {
                    current_speed = 0;
                    timer += Time.deltaTime;
                    if (timer >= delay_to_restart)
                    {
                        delay_the_boolean = false;
                        timer = 0;
                        //   Debug.Log("time is " + timer);
                    }
                }
                if (delay_the_boolean == false)
                {
                    if (direction == true)
                    {
                        //  Debug.Log(current_speed);
                        current_speed += acceleration * Time.deltaTime;
                        rb.MovePosition(transform.position + translation * current_speed);
                        for (int i = 0; i < 4; i++)
                        {
                            wheels[i].gameObject.GetComponent<Transform>().Rotate(0, 0, current_speed * wheel_rotation);
                        }
                    }
                    else if (direction == false)
                    {
                        //     Debug.Log(current_speed);
                        current_speed += acceleration * Time.deltaTime;
                        rb.MovePosition(transform.position + translation_to_left * current_speed);
                        for (int i = 0; i < 4; i++)
                        {
                            wheels[i].gameObject.GetComponent<Transform>().Rotate(0, 0, -current_speed * wheel_rotation);
                        }
                    }
                }
            }
            else
            {
                delay_the_boolean = true;
                current_speed = 0;
            }
        }
        else
		{
            diesel_sound.enabled = false;
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("TriggerToCraneDisplacement"))
		{
            direction = !direction;
            delay_the_boolean = true;
		}
	}
    public void Set_if_splatted_something(bool splttd)
	{
        splatted_something = splttd;
	}
}
