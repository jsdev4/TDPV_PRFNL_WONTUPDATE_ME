using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        animator = GetComponent<Animator>();
        computer_light = GetComponentInChildren<Light>();
        checkpoint_passed = false;
        checkpoint_enabled = false;
        delay = 0;
    }
    void Update()
    {
        if (checkpoint_passed == true && checkpoint_enabled == false)
        {
            if(Input.GetKeyUp(KeyCode.F))
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
        if(checkpoint_passed==false&&checkpoint_enabled==true)
        {
            delay += Time.deltaTime;
            if(delay>=1)
            {
                computer_light.enabled = true;
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
}
