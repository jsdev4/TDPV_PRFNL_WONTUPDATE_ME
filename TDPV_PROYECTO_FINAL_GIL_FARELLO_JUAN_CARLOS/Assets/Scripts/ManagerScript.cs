using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class ManagerScript : MonoBehaviour
{
    public float time_counter;
    private float time_counter_script_inside;
    private float delay_for_reset_game;
    private bool paused;
    private bool changed;
    private bool out_of_time;
    public GameObject enemy;
    public Texture aTexture;
    public Font game_font;
    public Text pause_text;
    public GameObject gray_quad_for_pause;
    public GameObject lights;
    public GameObject player;
    public GameObject battery_icon;
    public GameObject blacknened_background;
    public Text text_on_screen;
    private int minutes;
    private int seconds;
    void Start()
    {
        time_counter_script_inside = time_counter;
        delay_for_reset_game = 0;
        changed = false;
        paused = false;
        out_of_time = false;
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
                enemy.gameObject.GetComponent<EnemyController>().Set_if_can_attack(false);
                battery_icon.gameObject.GetComponent<MeshRenderer>().enabled = false;
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
                enemy.gameObject.GetComponent<EnemyController>().Set_if_can_attack(true);
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
        if(out_of_time==true&&player.gameObject.GetComponent<CharController>().Get_number_of_lifes()>0)
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
        if(out_of_time==true&&player.gameObject.GetComponent<CharController>().Get_number_of_lifes()==0)
        {
            time_counter_script_inside = 0;
            //last point qhen the player dies, from here can be added another scene or return to main menu
        }
    }
   /* private void OnGUI()
    {
        GUI.skin.label.font = game_font;
       
        if (paused == false)
        {
            minutes = Mathf.FloorToInt(time_counter_script_inside / 60F);
            seconds = Mathf.FloorToInt(time_counter_script_inside - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            GUI.skin.label.fontSize = 50;
            GUI.Label(new Rect((Screen.width / 2) - 130, 30, 250, 100), niceTime);
        }
    }*/
}