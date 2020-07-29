using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private int random_to_move;
    public float speed;
    public float delay;
    private float timer;
    private bool direction;
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
        timer += Time.deltaTime;
        if(timer>=delay)
		{
            Generate_direction();
            Generate_action();
            timer = 0;
		}
     
		
        if(random_to_move==0)
		{
            Debug.Log("adction is 0");
            quad.gameObject.GetComponent<Animator>().Play("femaleNpcIdle");
            if(direction==false)
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
        else if (random_to_move==1)
		{
            Debug.Log("adction is 1");
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
        if(collision.collider.CompareTag("Wall")||collision.collider.CompareTag("Glass")||collision.collider.CompareTag("Desktop"))
		{
            direction = !direction;
		}
	}
}
