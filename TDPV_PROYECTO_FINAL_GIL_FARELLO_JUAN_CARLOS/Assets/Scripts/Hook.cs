using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Hook : MonoBehaviour
{
    public int hook;
    public bool direction;
    public float speed;
    private Transform trnsfrm;
    public GameObject player;
    private bool player_on_it;
    public GameObject[] hooks;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
    }
    void Update()
    {
         Vector3 currentPos = trnsfrm.position;
         Vector3 currentPosfixed = new Vector3(currentPos.x, currentPos.y - 2f, currentPos.z);
         if (direction == true)
         {
             trnsfrm.Translate(Vector3.right * speed * Time.deltaTime);
         }
         else
         {
            trnsfrm.Translate(Vector3.left * speed * Time.deltaTime);
         }
         if (hook==0&&player_on_it == true)
         {
            hooks[1].SetActive(false);
            player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(true);
            player.gameObject.GetComponent<Rigidbody>().MovePosition(currentPosfixed);
            if (Input.GetKeyUp(KeyCode.F))
            {
                player_on_it = false;
            }
            if (Input.GetKeyUp(KeyCode.Space) && player.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == true)
            {  
                player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 7.5f, ForceMode.Impulse);        
                player_on_it = false;   
            }
            if (Input.GetKeyUp(KeyCode.Space) && player.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == false)
            {
                player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 7.5f, ForceMode.Impulse);
                player_on_it = false; 
            }        
        }      
        if (player_on_it == false)  
        {       
            player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(false);
            hooks[1].SetActive(true);    
        }
        if (hook == 1 && player_on_it == true)
        {
            hooks[0].SetActive(false);
                
            player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(true);
            player.gameObject.GetComponent<Rigidbody>().MovePosition(currentPosfixed);
            if (Input.GetKeyUp(KeyCode.F))
            {
                player_on_it = false;
            }
            if (Input.GetKeyUp(KeyCode.Space) && player.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == true)
            {
                player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 7.5f, ForceMode.Impulse);
                player_on_it = false;
            }
            if (Input.GetKeyUp(KeyCode.Space) && player.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == false)
            {
                player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 7.5f, ForceMode.Impulse);
                player_on_it = false;
            }   
            if (player_on_it == false)
            {
                player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(false);
                hooks[0].SetActive(true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HookCollider"))
        {
            direction = !direction;
        }
        if (collision.collider.CompareTag("Player"))
        {
            player_on_it = true;
        }
    }
    public void set_if_player_is_on_it(bool on_it)
	{
        player_on_it = on_it;
	}
}
