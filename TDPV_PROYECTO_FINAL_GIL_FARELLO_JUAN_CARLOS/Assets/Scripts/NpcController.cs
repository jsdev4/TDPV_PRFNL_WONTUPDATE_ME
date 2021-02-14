using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private bool on_screen;
    public bool is_static_npc;
    public bool in_level04;
    public bool is_male_npc;
    private int random_to_move;
    public float speed;
    public float delay;
    private float timer;
    public bool direction;
    private int direction_in_number;
    private Vector3 translation;
    private Vector3 translation_to_left;
    private Vector3 rotation_sprite;
    private Rigidbody rb;
    public GameObject quad;
    void Start()
    {
        timer = 0;
        translation = new Vector3(1, 0, 0);
        translation_to_left = new Vector3(-1, 0, 0);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (on_screen == true)
        {
            if (is_static_npc == false)
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    // Generate_direction();
                    if (in_level04 == false)
                    {
                        Generate_direction();
                        Generate_action();
                    }
                    else
                    {
                        //direction=false;
                    }
                    timer = 0;
                }
                if (is_male_npc == true)
                {
                    quad.gameObject.GetComponent<Animator>().Play("maleNpcWalking");
                    if (direction == false)
                    {
                        rb.MovePosition(transform.position + translation_to_left * speed * Time.deltaTime);
                        rotation_sprite = new Vector3(-1, 1, 1);
                        transform.localScale = rotation_sprite;
                    }
                    if (direction == true)
                    {
                        rb.MovePosition(transform.position + translation * speed * Time.deltaTime);
                        rotation_sprite = new Vector3(1, 1, 1);
                        transform.localScale = rotation_sprite;
                    }
                }
                if (random_to_move == 0)
                {
                    if (is_male_npc == false)
                    {
                        quad.gameObject.GetComponent<Animator>().Play("femaleNpcIdle");
                    }

                    if (direction == false)
                    {
                        rotation_sprite = new Vector3(-1, 1, 1);
                        transform.localScale = rotation_sprite;
                    }
                    else
                    {
                        rotation_sprite = new Vector3(1, 1, 1);
                        transform.localScale = rotation_sprite;
                    }
                }
                else if (random_to_move == 1)
                {
                    quad.gameObject.GetComponent<Animator>().Play("femaleNpcWalking");
                    if (direction == false)
                    {
                        rb.MovePosition(transform.position + translation_to_left * speed * Time.deltaTime);
                        rotation_sprite = new Vector3(-1, 1, 1);
                        transform.localScale = rotation_sprite;
                    }
                    if (direction == true)
                    {
                        rb.MovePosition(transform.position + translation * speed * Time.deltaTime);
                        rotation_sprite = new Vector3(1, 1, 1);
                        transform.localScale = rotation_sprite;
                    }
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    Generate_direction();
                    // Generate_action();
                    timer = 0;
                }
                if (is_male_npc == false)
                {
                    quad.gameObject.GetComponent<Animator>().Play("femaleNpcIdle");
                }
                if (is_male_npc == true)
                {
                    quad.gameObject.GetComponent<Animator>().Play("maleNpcIdle");
                }
                if (direction == false)
                {
                    rotation_sprite = new Vector3(-1, 1, 1);
                    transform.localScale = rotation_sprite;
                }
                else
                {
                    rotation_sprite = new Vector3(1, 1, 1);
                    transform.localScale = rotation_sprite;
                }
            }
        }
    }
    private void Generate_direction()
	{
        direction_in_number = Random.Range(0, 2);
        if (direction_in_number == 0)
        {
            direction = false;
        }
        if (direction_in_number == 1)
        {
            direction = true;
        }
    }
    private void Generate_action()
    {
        random_to_move = Random.Range(0, 2);
    }
    public void Set_direction(bool dir)
	{
        direction = dir;
	}
    private void OnCollisionEnter(Collision collision)
	{
        if(collision.collider.CompareTag("Wall")||collision.collider.CompareTag("Glass")||collision.collider.CompareTag("Desktop")||collision.collider.CompareTag("TriggerForPedestrian"))
		{
            direction = !direction;
		}
	}//add another tag named trigger eg
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("TriggerForPedestrian")||other.CompareTag("AvoidableObject")||other.CompareTag("MetallicStructure"))
		{
            direction = !direction;
		}
	}
	private void OnBecameVisible()
	{
        on_screen = true;
     //   Debug.Log("npc is on screen");
	}
	private void OnBecameInvisible()
	{
        on_screen = false;
      ///  Debug.Log("npc is not on screen");
	}
}
