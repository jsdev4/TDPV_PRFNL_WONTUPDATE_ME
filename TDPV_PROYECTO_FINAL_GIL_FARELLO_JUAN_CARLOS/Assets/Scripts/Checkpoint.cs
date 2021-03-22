using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public int checkpoint_number;
    private bool checkpoint_passed;
    private bool checkpoint_enabled;
    public GameObject player;
    public GameObject trigger_to_save;
    private Animator animator;
    private Light computer_light;
    private float delay;
    public Text[] very_interactive_text;
    public GameObject manager;
    void Start()
    {
        animator = GetComponent<Animator>();
        computer_light = GetComponentInChildren<Light>();
        checkpoint_passed = false;
        checkpoint_enabled = false;
        delay = 0;
        very_interactive_text[0].CrossFadeAlpha(0.0f, 0.05f, false);
        very_interactive_text[1].CrossFadeAlpha(0.0f, 0.05f, false);
    }
    void Update()
    {
        if (manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false)
        {
           
            if (checkpoint_passed == true && checkpoint_enabled == false)
            {
                very_interactive_text[0].enabled = true;
                very_interactive_text[0].CrossFadeAlpha(1.0f, .075f, false);
                if (Input.GetKeyUp(KeyCode.F))
                {

                    animator.enabled = true;
                    checkpoint_number += 1;
                    player.gameObject.GetComponent<CharController>().Set_respawn_point(checkpoint_number);
                    trigger_to_save.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;

                    Debug.Log("checkppoint :" + checkpoint_number);
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
                delay += Time.deltaTime;
                if (delay >= 1)
                {
                    computer_light.enabled = true;
                }

            }
            if (checkpoint_passed == false && checkpoint_enabled == false)
            {
                very_interactive_text[0].enabled = true;
                very_interactive_text[0].CrossFadeAlpha(0f, .5f, false);
            }


            if (checkpoint_passed == true && checkpoint_enabled == true)
            {
                very_interactive_text[0].enabled = true;
                very_interactive_text[1].CrossFadeAlpha(1.0f, .075f, false);
            }
        }
        else
		{
            for (int i = 0; i < very_interactive_text.Length; i++)
            {
                very_interactive_text[i].enabled = false;
            }
        }
    }
      private void OnTriggerEnter(Collider other)
      {
          if(other.gameObject.CompareTag("Player"))
          {
              checkpoint_passed = true;
          }
      }
      private void OnTriggerExit(Collider other)
      {
          if (other.gameObject.CompareTag("Player"))
          {
             checkpoint_passed = false;
          }
      }
}
