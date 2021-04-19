using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForPlayingSound01 : MonoBehaviour
{
    private AudioSource audio_s;
    public GameObject manager;
    void Start()
    {
        audio_s = GetComponent<AudioSource>();
        audio_s.Play();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(manager.gameObject.GetComponent<ManagerScript>().Return_if_paused()==false)
		{
            audio_s.enabled = true;
		}
        else
		{
            audio_s.enabled = false;
		}
    }
}
