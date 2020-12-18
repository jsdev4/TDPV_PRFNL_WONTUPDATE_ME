using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForWheelSplat : MonoBehaviour
{
    private float timer;
    private bool splatted;
    private bool stopped;
    private BoxCollider bx;
    public GameObject player;
 
    void Start()
    {
        bx = GetComponent<BoxCollider>();
        splatted = false;
        stopped = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(splatted==true&&stopped==false)
		{
            player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
            stopped = true;
           
			/*else
			{
                GetComponentInParent<CraneController>().Set_if_splatted_something(false);
                bx.enabled = true;
                splatted = false;
            }*/
        }
        if(splatted==true&&stopped==true)
		{
            GetComponentInParent<CraneController>().Set_if_splatted_something(true);

            if (player.gameObject.GetComponent<CharController>().Player_is_alive() == false)
            {
                bx.enabled = false;

            }
            else
            {
                GetComponentInParent<CraneController>().Set_if_splatted_something(false);
                bx.enabled = true;
                splatted = false;
                stopped = false;
            }
        }
      

    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            splatted = true;
            stopped = false;
		}
	}
}
