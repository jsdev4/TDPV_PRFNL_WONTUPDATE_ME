using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerForPacPunk : MonoBehaviour
{
    public float speed;
    public float jump_speed;
    private bool on_ground;
    private bool is_jumping;
    private bool can_move;
    private bool is_alive;
    private bool can_eat_enemies;
    private int lifes;
    private Rigidbody rb;
    public GameObject quad;
    void Start()
    {
        lifes = 1;
        rb = GetComponent<Rigidbody>();
        can_move = true;
        is_alive = true;
        can_eat_enemies = false;
    }
    void Update()
    {
        float translationX =Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float translation = Input.GetAxis("Vertical") * speed* Time.deltaTime;
        transform.Translate(translationX, 0, translation);
        if (can_move==true)
		{
            if(is_alive==true)
			{
                if (Input.GetKey(KeyCode.A))
				{
                    quad.gameObject.GetComponent<Transform>().localScale=new Vector3(-1, 1, 1);
				}
                if (Input.GetKey(KeyCode.D))
                {
                    quad.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                }
                if (Input.GetKey(KeyCode.W))
                {
                  
                }
                if (Input.GetKey(KeyCode.S))
                {
                  
                }
                if(on_ground==true)
				{
                    if(Input.GetKeyDown(KeyCode.Space))
					{
                        is_jumping = true;
                        rb.AddForce(Vector3.up * jump_speed ,ForceMode.Impulse);
					}
                    if(Input.GetKeyUp(KeyCode.Space))
					{
                        is_jumping = true;
                        on_ground = false;
					}
				}
               
            }
		}
        if(can_move==false)
		{
            if(is_alive==false)
			{
                quad.gameObject.GetComponent<Animator>().Play("pacpunkdying");
			}


		}
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("ground") )
        {
            on_ground = true;
            is_jumping = false;
        }
    }
}

