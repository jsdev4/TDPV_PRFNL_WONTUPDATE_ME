using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour
{
    private Animator anim;
    //public GameObject player;
    private bool playing_fade_in;
    private bool playing_fade_out;


    private bool animation_complete;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playing_fade_out==true)
		{
            anim.Play("Fade_out");
            playing_fade_out = false;
        }
        if (playing_fade_in == true)
        {
            anim.Play("Fade_in");
            playing_fade_in = false;
        }

    }
    public void Set_the_fade_out()
	{
        playing_fade_out =true;
	}
    
    public void Fade_is_complete()
	{
        animation_complete = true;
       
	}
    public void Disable_fade_screen()
	{
        gameObject.SetActive(false);
	}
    public bool Return_if_playing_fade()
	{
        return playing_fade_out;
	}
    public bool Return_animation_complete()
	{
        return animation_complete;
	}public void Set_fade_in()
	{
        playing_fade_in = true;
	}
    public void Set_animation_complete(bool is_complete)
	{
        animation_complete = is_complete;
	}
}
