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
    void Start()
    {
       
        checkpoint_passed = false;
        checkpoint_enabled = false;
    }
    void Update()
    {

            if (checkpoint_passed == true && checkpoint_enabled == false)
            {
            if(Input.GetKeyUp(KeyCode.F))
            {
                checkpoint_number += 1;
                player.gameObject.GetComponent<CharController>().Set_respawn_point(checkpoint_number);
                trigger_to_save.gameObject.GetComponentInChildren<BoxCollider>().enabled = false; 
                Debug.Log("checkppoint :" + checkpoint_number);
                checkpoint_passed = false;
                checkpoint_enabled = true;
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
