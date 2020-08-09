using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerForPacPunk : MonoBehaviour
{
    public float speed;
    public float jump_speed;
    private bool on_ground;
  
    private bool can_move;
    private bool is_alive;
    private bool can_eat_enemies;
    private int lifes;
    private Vector3 firstPos;
    private Transform trnsfrm;
    private Rigidbody rb;
    public GameObject quad;
    
    void Start()
    {
        lifes =3;
        trnsfrm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        can_move = true;
        is_alive = true;
        can_eat_enemies = false;
        firstPos = trnsfrm.position;
    }
    void Update()
    {
       
        if (can_move==true)
		{
            if(is_alive==true)
			{
                quad.gameObject.GetComponent<Animator>().Play("pacpunkIdle");
                float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
                transform.Translate(translationX, 0, translation);
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
    public void Set_if_player_die(bool move,bool alive)
	{
        can_move = move;
        is_alive = alive;
       
	}
    public void Set_initial_pos()
	{
        trnsfrm.position = firstPos;
	}
    public int Return_number_of_lifes()
	{
        return lifes;
	}
    public void Decrease_life()
	{
        lifes -= 1;
        Debug.Log("life is" + lifes);
	}
}

