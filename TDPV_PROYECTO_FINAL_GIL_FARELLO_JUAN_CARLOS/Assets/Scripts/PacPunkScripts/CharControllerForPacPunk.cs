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
    private Rigidbody rb;
    public GameObject quad;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        can_move = true;
        is_alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float translationX =Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float translation = Input.GetAxis("Vertical") * speed* Time.deltaTime;
       // translation *= Time.deltaTime;
        transform.Translate(translationX, 0, translation);
        if (can_move==true)
		{
            if(is_alive==true)
			{
               
                
                if (Input.GetKey(KeyCode.A))
				{
                    //rb.MovePosition(transform.position + translationX * speed * Time.deltaTime);
                    quad.gameObject.GetComponent<Transform>().localScale=new Vector3(-1, 1, 1);
				}
                if (Input.GetKey(KeyCode.D))
                {
                    //rb.MovePosition(transform.position + translationX * speed * Time.deltaTime);
                    quad.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                }
                if (Input.GetKey(KeyCode.W))
                {
                   // rb.MovePosition(new Vector3(transform.position.x, transform.position.y, translation * Time.deltaTime));
                   // quad.gameObject.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
                }
                if (Input.GetKey(KeyCode.S))
                {
                  // rb.MovePosition(new Vector3(transform.position.x, transform.position.y,( translation * Time.deltaTime)*-1));
                    // rb.MovePosition(transform.position + translationZ * speed * Time.deltaTime);
                    // quad.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                }
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

