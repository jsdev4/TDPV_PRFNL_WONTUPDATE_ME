using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckpointMainSV : MonoBehaviour
{
    

    private Animator anim;
    public int checkpoint_number;
    private bool checkpoint_passed;
    private bool checkpoint_enabled;
    private string light_sv_color;
    public GameObject player;
    public GameObject[] trigger_to_save;
    public Text[] very_interactive_text;
    public GameObject manager;
    public AudioSource keyboard_sound;
    void Start()
    {
        anim = GetComponent<Animator>();
        checkpoint_enabled = false;
        light_sv_color = "#00FFAB";
     
    }
    void Update()
    {
        if (manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false)
        {
            if (checkpoint_passed == true && checkpoint_enabled == false)
            {
                Color newCol;
                ColorUtility.TryParseHtmlString(light_sv_color, out newCol);
                very_interactive_text[0].enabled = true;
                very_interactive_text[0].CrossFadeAlpha(1.0f, 0.75f, false);
                if (Input.GetKeyUp(KeyCode.F))
                {

                    checkpoint_number += 1;
                    player.gameObject.GetComponent<CharController>().Set_respawn_point(checkpoint_number);
                    for (int i = 0; i < 4; i++)
                    {
                        trigger_to_save[i].gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                    anim.Play("main_sv_unlocked");
                    keyboard_sound.Play();
                    gameObject.GetComponentInChildren<Light>().color = newCol;
                    Debug.Log("pressed0");
                    checkpoint_passed = false;
                    checkpoint_enabled = true;
                }
            }
            if (checkpoint_passed == false && checkpoint_enabled == true)
            {
                very_interactive_text[0].enabled = true;
                very_interactive_text[1].enabled = true;
                very_interactive_text[0].CrossFadeAlpha(0f, .5f, false);
                very_interactive_text[1].CrossFadeAlpha(0f, .5f, false);
            }
            if (checkpoint_passed == true && checkpoint_enabled == true)
            {
                very_interactive_text[1].enabled = true;
                very_interactive_text[1].CrossFadeAlpha(1.0f, .75f, false);
            }
            if (checkpoint_passed == false && checkpoint_enabled == false)
            {
                very_interactive_text[0].enabled = true;
                very_interactive_text[0].CrossFadeAlpha(0f, .5f, false);
            }
        }
        else
		{
            for(int i =0;i<very_interactive_text.Length;i++)
			{
                very_interactive_text[i].enabled = false;
			}
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            checkpoint_passed = true;
		}
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpoint_passed = false;
        }
    }
}
