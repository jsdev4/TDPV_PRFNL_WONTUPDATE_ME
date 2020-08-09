using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PacPunkManager : MonoBehaviour
{
    private float timer;
    public float delay_to_pause;
    public float delay_to_restart;
    private float timer_to_restart;
    public float max_time;
    public float critical_time;
    private int icons_collected;
    private bool special_icon_collected;
    private bool player_was_hitted;
    private int numberOfTaggedObjects;
    private int numberOfSpecialTaggedObject;
    public GameObject[] enemy_ghost;
    public GameObject player;
    void Start()
    {
        numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("WaitingIconBall").Length;
        numberOfSpecialTaggedObject = GameObject.FindGameObjectsWithTag("SpecialIcon").Length;
        timer = 0;
        timer_to_restart = 0;
        special_icon_collected = false;
        player_was_hitted = false;
        icons_collected = 0;
        Debug.Log(numberOfTaggedObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if(special_icon_collected==true)
		{//enemies are good
           
            timer += Time.deltaTime;
            //call to enemies status bad or good
            if (timer >= critical_time)
			{
                //enemies are good
                //enemies flashing;
			}
            if (timer >= max_time)
            {
                //enemies back to normal
                //enemies are bad
                Debug.Log("Special icon is out");
                timer = 0;
                special_icon_collected = false;
            }
		}
        if(icons_collected==numberOfTaggedObjects+numberOfSpecialTaggedObject)
		{
            //victory condition
            Debug.Log("all the objects were collected");
		}
   
            if (player_was_hitted == true&& player.gameObject.GetComponent<CharControllerForPacPunk>().Return_number_of_lifes()>=1)
            {
                player.gameObject.GetComponent<CharControllerForPacPunk>().Set_if_player_die(false, false);
                
                for (int i = 0; i < 4; i++)
                {
                    enemy_ghost[i].gameObject.GetComponent<NavMeshAgent>().speed = 0;
                }
                timer_to_restart += Time.deltaTime;
                if (timer_to_restart > delay_to_pause && timer_to_restart < delay_to_restart)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Set_initial_pos();
                        enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Set_if_player_can_be_hitted();
                        enemy_ghost[i].gameObject.GetComponent<NavMeshAgent>().speed = 5;
                    }
                    player.gameObject.GetComponent<CharControllerForPacPunk>().Set_if_player_die(true, true);
                    player.gameObject.GetComponent<CharControllerForPacPunk>().Set_initial_pos();
                player.gameObject.GetComponent<CharControllerForPacPunk>().Decrease_life();
                    timer_to_restart = 0;
                }
                player_was_hitted = false;
               
            }
    
        if (player_was_hitted == false && player.gameObject.GetComponent<CharControllerForPacPunk>().Return_number_of_lifes() == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Set_initial_pos();
            }
            player.gameObject.GetComponent<CharControllerForPacPunk>().Set_initial_pos();
            player.gameObject.GetComponent<CharControllerForPacPunk>().Set_if_player_die(false, false);
            for (int i = 0; i < 4; i++)
            {
                enemy_ghost[i].gameObject.GetComponent<NavMeshAgent>().speed = 0;
            }
            Debug.Log("back to level03");
        }
    }
    public void Increase_icons_collected()
	{
        icons_collected += 1;
        Debug.Log(icons_collected);
	}
    public void Set_special_icon_collected()
	{
        icons_collected += 1;
        Debug.Log("special icon is collected");
        special_icon_collected = true;
	}
    public bool Get_if_special_icon_collected()
	{
        return special_icon_collected;
	}
    public void Set_if_player_die()
	{
        player_was_hitted = true;
	}
    public bool Get_if_player_die()
	{
        return player_was_hitted;
	}
   
}
