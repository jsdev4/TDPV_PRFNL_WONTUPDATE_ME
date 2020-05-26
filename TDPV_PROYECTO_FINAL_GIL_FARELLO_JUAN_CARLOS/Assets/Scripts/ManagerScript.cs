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
    public Text text_on_screen;
    private int minutes;
    private int seconds;
    private int cells_on_timer;
    void Start()
    {
        time_counter_script_inside = time_counter;
        delay_for_reset_game = 0;
        changed = false;
        paused = false;
        out_of_time = false;
        if(time_counter_script_inside>0&&time_counter_script_inside<=60)
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
                    if (minutes == 0 && seconds == 0)
                    {
                        player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                        changed = true;
                    }
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
        }
        else if(time_counter_script_inside<0&&out_of_time==false)
        {
            player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
            out_of_time = true;
        }

        //rever este fragmento de codigo para que no respawnee en el ultimo check y con 5 mins
        //la idea es que se termine el tiempo  y pierdas indistinto que las vidas sean mas 0
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
        }//same here
        if(out_of_time==true&&player.gameObject.GetComponent<CharController>().Return_number_of_lifes()==0)
        {
            time_counter_script_inside = 0;
            //last point qhen the player dies, from here can be added another scene or return to main menu
        }

       
    }
    public int Get_cells_for_timer()
    {
        return cells_on_timer;
    }
}