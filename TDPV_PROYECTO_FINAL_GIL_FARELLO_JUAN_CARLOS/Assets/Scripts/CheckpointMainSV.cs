using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMainSV : MonoBehaviour
{
    

    private Animator anim;
    public int checkpoint_number;
    private bool checkpoint_passed;
    private string light_sv_color;
    public GameObject player;
    public GameObject trigger_to_save;
   // private Color point_light;
    void Start()
    {
        anim = GetComponent<Animator>();
        
        light_sv_color = "#00FFAB";
       // point_light = GetComponentInChildren<Light>().color;
    }
    void Update()
    {
       
        if (checkpoint_passed==true)
        {
            Color newCol;
            ColorUtility.TryParseHtmlString(light_sv_color, out newCol);
            if (Input.GetKeyUp(KeyCode.F))
			{
               
                checkpoint_number += 1;
                player.gameObject.GetComponent<CharController>().Set_respawn_point(checkpoint_number);
                trigger_to_save.gameObject.GetComponent<BoxCollider>().enabled = false;
                anim.Play("main_sv_unlocked");
                //point_light.color = ColorUtility.TryParseHtmlString(light_sv_color, out newCol);
                
                {
                    gameObject.GetComponentInChildren<Light>().color= newCol;
                }
                Debug.Log("pressed0");
                    checkpoint_passed = false;
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
