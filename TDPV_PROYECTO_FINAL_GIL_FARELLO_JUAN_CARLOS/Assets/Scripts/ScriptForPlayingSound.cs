using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForPlayingSound : MonoBehaviour
{
    private bool first_step;
    private bool second_step;
    public AudioSource[] steps;
    void Start()
    {
       // steps = GetComponent<AudioSource>();
      //  steps[1] = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(first_step==true)
		{
            steps[0].Play();
           
		}
        if (second_step == true)
        {
            steps[1].Play();
        }
    }
    public void Set_first_step()
	{
        first_step = true;
        second_step = false;
	}
    public void Set_second_step()
	{
        second_step = true;
        first_step = false;
	}
}
