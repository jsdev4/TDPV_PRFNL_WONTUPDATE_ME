using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ed102AnimController : MonoBehaviour
{
    private bool key_was_pressed;
    private bool ed102_is_out;
    private Animator anim;
    public GameObject screen_object;
    public GameObject computer;
    void Start()
    {
        key_was_pressed = false;
        ed102_is_out = false;
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {

        if (key_was_pressed == false)
        {
            anim.Play("Ed102pcing");
            computer.gameObject.GetComponent<Animator>().Play("VintageComputerCode");
        }
        if (key_was_pressed == true)
        {
            anim.Play("Ed102pcing_and_later_runnning");
            computer.gameObject.GetComponent<Animator>().Play("VintageComputerSSShutdown");
            if(computer.gameObject.GetComponent<TextEventsController>().Return_if_to_next_scene()==true)
			{
                computer.gameObject.GetComponentInChildren<Light>().enabled = false;
			}
        }
       
        if(screen_object.gameObject.GetComponent<TransitionSceneController>().Return_if_key_was_pressed()==true)
		{
            key_was_pressed = true;
		}
        
    }
   
}
