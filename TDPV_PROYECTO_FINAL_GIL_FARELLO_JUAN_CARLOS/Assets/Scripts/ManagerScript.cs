
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.UI;


public class ManagerScript : MonoBehaviour
{
    public float time_counter;
    private float time_counter_script_inside;
    private float delay_for_reset_game;
    private bool paused;
    private bool changed;
    private bool out_of_time;
    private bool run_out_of_cells;
    private bool has_respawned_from_mini_game;
    public GameObject[] enemy;
    public Texture aTexture;
    public Font game_font;
    public Text pause_text;
    public GameObject gray_quad_for_pause;
    public GameObject lights;
    public GameObject player;
    public GameObject battery_icon;
    public GameObject blacknened_background;
    public GameObject life_icon;
    public GameObject[] respawn_point;
    public GameObject special_computer_mini_game;
    public Text text_on_screen;
    public Text continue_text;
    public Text return_text;
    private int minutes;
    private int seconds;
    private int cells_on_timer;
    private int option;

    private Color32 unselect_color;
    private Color32 select_color;

    public GameObject fader;
	void Awake()
	{
        fader.SetActive(true);
        fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
    }
	void Start()
    {

        has_respawned_from_mini_game = false;
        //condition for the returning from other scenes
       if (ManagerKeeper.Get_if_other_scene() == true&&ManagerKeeper.Get_if_mini_game_completed()==false)
        {
            time_counter_script_inside = ManagerKeeper.Get_old_time_script_inside();
            special_computer_mini_game.gameObject.GetComponent<BoxCollider>().enabled = false;
            player.gameObject.GetComponent<Transform>().position = ManagerKeeper.Get_old_players_position();
            player.gameObject.GetComponent<CharController>().Set_lifes(ManagerKeeper.Get_old_number_of_lifes());
            player.gameObject.GetComponent<CharController>().Keep_respawn_point(ManagerKeeper.Get_old_respawn_point());
        }
        if(ManagerKeeper.Get_if_other_scene()==true&&ManagerKeeper.Get_if_mini_game_completed()==true)
		{
            Debug.Log(ManagerKeeper.Get_respawn_point());               
                time_counter_script_inside = ManagerKeeper.Get_old_time_script_inside();
            special_computer_mini_game.gameObject.GetComponent<BoxCollider>().enabled = false;
            player.gameObject.GetComponent<CharController>().Keep_respawn_point(ManagerKeeper.Get_old_respawn_point());
                
                has_respawned_from_mini_game = true;
            
            if (ManagerKeeper.Get_respawn_point() == 0)
            {
                player.gameObject.GetComponent<Transform>().position = respawn_point[0].gameObject.GetComponent<Transform>().position;
            }
            if (ManagerKeeper.Get_respawn_point() == 1)
            {
                player.gameObject.GetComponent<Transform>().position = respawn_point[1].gameObject.GetComponent<Transform>().position;
            }
            if (ManagerKeeper.Get_respawn_point() == 2)
            {
                player.gameObject.GetComponent<Transform>().position = respawn_point[2].gameObject.GetComponent<Transform>().position;
            }
            if (ManagerKeeper.Get_respawn_point() == 3)
            {
                player.gameObject.GetComponent<Transform>().position = respawn_point[3].gameObject.GetComponent<Transform>().position;
            }
        }
        //else
        else if(ManagerKeeper.Get_if_other_scene() == false && ManagerKeeper.Get_if_mini_game_completed() == true|| ManagerKeeper.Get_if_other_scene() == false && ManagerKeeper.Get_if_mini_game_completed() == false)
        {
            time_counter_script_inside = time_counter;
        }
        delay_for_reset_game = 0;
        changed = false;
        paused = false;
        out_of_time = false;
        run_out_of_cells = false;
        option = 0;
        select_color= new Color32(72, 58, 176,255);
        unselect_color = new Color32(149,13,76,255);
;        if(time_counter_script_inside>0&&time_counter_script_inside<=60)
        {
            player.gameObject.GetComponent<CharController>().Set_number_of_cells(1);
            cells_on_timer = 1;
        }
        if (time_counter_script_inside >60 && time_counter_script_inside <= 120)
        {
            player.gameObject.GetComponent<CharController>().Set_number_of_cells(2);
            cells_on_timer = 2;
        }
        if (time_counter_script_inside > 120 && time_counter_script_inside <= 180)
        {
            player.gameObject.GetComponent<CharController>().Set_number_of_cells(3);
            cells_on_timer = 3;
        }
        if (time_counter_script_inside > 180 && time_counter_script_inside <= 240)
        {
            player.gameObject.GetComponent<CharController>().Set_number_of_cells(4);
            cells_on_timer = 4;
        }
        if (time_counter_script_inside >240 && time_counter_script_inside <=999999999)
        {
            player.gameObject.GetComponent<CharController>().Set_number_of_cells(5);
            cells_on_timer = 5;
        }
    }
    void Update()
    {
        time_counter_script_inside -= Time.deltaTime;
        if (time_counter_script_inside > 0)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                paused = !paused;
            }
            if (paused == true)
            {
                Time.timeScale = 0;
                player.gameObject.GetComponent<CharController>().Set_if_player_can_move(false);
                foreach (GameObject child in enemy)
                {
                    child.gameObject.SetActive(false);
                }
                blacknened_background.gameObject.GetComponent<MeshRenderer>().enabled = false;
                gray_quad_for_pause.gameObject.GetComponent<MeshRenderer>().enabled = true;
                lights.SetActive(false);
                pause_text.gameObject.GetComponent<Text>().enabled = true;
                continue_text.gameObject.GetComponent<Text>().enabled = true;
                return_text.gameObject.GetComponent<Text>().enabled = true;
                if (option == 0)
                {
                    continue_text.gameObject.GetComponent<Text>().color = select_color;
                    if(Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow))
                    {
                        option = 1;
                        continue_text.gameObject.GetComponent<Text>().color = unselect_color;
                    }
                    if(Input.GetKeyUp(KeyCode.Return))
                    {
                        paused = false;
                    }
                }
                if(option==1)
                {
                    return_text.gameObject.GetComponent<Text>().color = select_color;
                    if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.UpArrow))
                    {
                        option = 0;
                        return_text.gameObject.GetComponent<Text>().color = unselect_color;
                    }
                    //from here, main menu scene must be added
                }
            }
            if (paused == false)
            {
                Time.timeScale = 1;
                minutes = Mathf.FloorToInt(time_counter_script_inside / 60F);
                seconds = Mathf.FloorToInt(time_counter_script_inside - minutes * 60);
                string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
                text_on_screen.text = niceTime;
                player.gameObject.GetComponent<CharController>().Set_if_player_can_move(true);
                foreach (GameObject child in enemy)
                {
                    if (child != null)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                battery_icon.gameObject.GetComponent<MeshRenderer>().enabled = true;
                blacknened_background.gameObject.GetComponent<MeshRenderer>().enabled = true;
                lights.SetActive(true);
                gray_quad_for_pause.gameObject.GetComponent<MeshRenderer>().enabled = false;
                pause_text.gameObject.GetComponent<Text>().enabled = false;
                continue_text.gameObject.GetComponent<Text>().enabled =false;
                return_text.gameObject.GetComponent<Text>().enabled = false;
                if (changed == false)
                {
                    if (minutes == 4 && seconds == 0)
                    {
                        player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                        changed = true;
                    }
                    if (minutes == 2 && seconds == 0)
                    {
                        player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                        changed = true;
                    }
                  /*  if (minutes == 0 && seconds == 0)
                    {
                        player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                        changed = true;
                    }*/
                    //ver si poner un bool y llamar una fuincion o metodo desde acá.
                }
                if(changed==true)
                {
                    if(minutes==3&&seconds==0)
                    {
                        player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                        changed = false;
                    }
                    if (minutes == 1 && seconds == 0)
                    {
                        player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                        changed = false;
                    }
                }    
            }
             if(player.gameObject.GetComponent<CharController>().Return_number_of_cells()==0&&run_out_of_cells==false)
            {
                if(player.gameObject.GetComponent<CharController>().Get_if_dead_by_enemy() == false)
                {
                    player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
                    foreach (GameObject child in enemy)
                    {
                        child.gameObject.GetComponent<EnemyController>().Reset_number_of_hits();
                    }
                    run_out_of_cells = true;
                   
                }
               
            }
           
        }
        else if(time_counter_script_inside<=0&&out_of_time==false)
        {
             player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
            out_of_time = true;
        }
        if(out_of_time==true&&player.gameObject.GetComponent<CharController>().Return_number_of_lifes()>0)
        { 
            time_counter_script_inside = 0;
            delay_for_reset_game += Time.deltaTime;
            if (delay_for_reset_game > 3)
            {
                time_counter_script_inside = time_counter;
                time_counter -= Time.deltaTime;
                delay_for_reset_game = 0;
                out_of_time = false;    
            }
        }
        if(out_of_time==true&&player.gameObject.GetComponent<CharController>().Return_number_of_lifes()==0)
        {
            time_counter_script_inside = 0;
            //last point qhen the player dies, from here can be added another scene or return to main menu
        }
    }
    public float Set_current_time()
	{
        return time_counter_script_inside;
	}
    public int Get_cells_for_timer()
    {
        return cells_on_timer;
    }
    public void Reset_run_out_of_cells(bool reset)
    {
        run_out_of_cells = reset;
    }
    public void Set_pause(bool psd)
	{
        paused = psd;
	}
}