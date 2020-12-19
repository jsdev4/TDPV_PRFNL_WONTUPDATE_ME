using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharControllerForPacPunk : MonoBehaviour
{
    public float speed;
    public float jump_speed;
    private bool can_move;
    private bool is_alive;
    private bool moving_up;
    private bool moving_down;
    private int lifes;
    private Vector3 firstPos;
    private Transform trnsfrm;
    public GameObject quad;
    
    void Start()
    {
        lifes =3;
        trnsfrm = GetComponent<Transform>();
        can_move = true;
        is_alive = true;
        moving_up = false;
        moving_down = false;
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
                if(Input.GetKeyDown(KeyCode.W))
				{
                    moving_up = true;
				}
                if (Input.GetKeyDown(KeyCode.S))
                {
                    moving_down = true;
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    moving_up = false;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    moving_down = false;
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
        if(can_move==false)
		{
            if(is_alive==true)
			{
                quad.gameObject.GetComponent<Animator>().Play("pacpunkIdle");
            }
		}
    }
    public void Set_if_player_is_alive(bool move,bool alive)
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
    public bool Set_moving_up()
	{
        return moving_up;
	}
}

