
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagerScript : MonoBehaviour
{
    public float time_counter;
    private float time_counter_script_inside;
    private float delay_for_reset_game;
    private float timer_for_music_start;
    //
    private float timer_to_restart_level;
    private bool paused;
    private bool changed;
    private bool out_of_time;
    private bool run_out_of_cells;
    private bool to_main_menu;
    private bool go_to_retry;
    private bool start_music;
    private bool music_to_zero;
    public int number_of_level;//comment for security purposes
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
    private int song_number;
    private Color32 unselect_color;
    private Color32 select_color;
    public GameObject[] objects_to_hide_when_paused;
    public GameObject fader;
    public AudioSource[] interface_sounds;
    public AudioSource[] music;
	void Awake()
	{
        fader.SetActive(true);
        fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
    }
	void Start()
    {
        to_main_menu = false;
        start_music = false;
        song_number = 0;
        if (number_of_level == 0)
		{
            ManagerKeeper.Set_current_level(0);
		}
        if (number_of_level == 1)
        {
            ManagerKeeper.Set_current_level(1);
        }
        if (number_of_level == 2)
        {
            ManagerKeeper.Set_current_level(2);
        }
        if (number_of_level == 3)
        {
            ManagerKeeper.Set_current_level(3);
        }
        if (number_of_level == 4)
        {
            ManagerKeeper.Set_current_level(4);
        }
        if (number_of_level == 5)
        {
            ManagerKeeper.Set_current_level(5);
        }

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
        go_to_retry = false;
        option = 0;
        timer_to_restart_level = 0;
        timer_for_music_start = 0;
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
        
        if (ManagerKeeper.Get_number_of_tries_availables() > 0)
        {
            time_counter_script_inside -= Time.deltaTime;
            if (start_music == false)
            {
                timer_for_music_start += Time.deltaTime;
            if (timer_for_music_start > 2f)
            {
                if(song_number==0)
				{
                    music[0].enabled = true;
                    music[0].Play();
                    music[1].enabled = false;
                }
                if (song_number == 1)
                {
                    music[1].enabled = true;
                    music[1].Play();
                    music[0].enabled = false;
                }
               // music[song_number].Play();
                start_music = true;
            }
            }

            if (start_music==true)
			{
                if(music[song_number].volume<.1f)
				{
                    music[song_number].volume+= .02f * Time.deltaTime;
                }
                else
				{
                    music[song_number].volume = 0.1f;

                }

			}
            if(music[song_number].isPlaying==false&&paused==false)
			{
                song_number += 1;
                if(song_number==2)
				{
                    song_number = 0;
				}
                start_music = false;
			}
            
            
            if (time_counter_script_inside > 0)
            {
                if (Input.GetKeyUp(KeyCode.P))
                {
                    option = 0;
                    paused = !paused; 
                }
                if (paused == true)
                {
                    Time.timeScale = 0;
                    if(start_music==true)
					{
                        if(song_number==0)
						{
                            music[0].Pause();
                        }
                        if (song_number == 1)
                        {
                            music[1].Pause();
                        }

                    }
                    player.gameObject.GetComponent<CharController>().Set_if_player_can_move(false);
                    foreach (GameObject child in enemy)
                    {
                        if (child != null)
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                   for(int i=0;i<objects_to_hide_when_paused.Length;i++)
					{
                        objects_to_hide_when_paused[i].SetActive(false);
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
                        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                        {
                            option = 1;
                            continue_text.gameObject.GetComponent<Text>().color = unselect_color;
                            interface_sounds[0].Play();
                        }
                        if (Input.GetKeyUp(KeyCode.Return))
                        {
                            interface_sounds[1].Play();
                            paused = false;
                        }
                    }
                    if (option == 1)
                    {
                        return_text.gameObject.GetComponent<Text>().color = select_color;
                        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)&&to_main_menu==false)
                        {
                            option = 0;
                            return_text.gameObject.GetComponent<Text>().color = unselect_color;
                            interface_sounds[0].Play();
                        }
                        if(Input.GetKeyUp(KeyCode.Return))
						{
                            interface_sounds[1].Play();
                            to_main_menu = true;
                            paused = false;
                        }
                    }
                }
                if (paused == false)
                {
                    Time.timeScale = 1;
                    if (start_music == true)
                    {
                        if (song_number == 0)
                        {
                            music[0].UnPause();
                        }
                        if (song_number == 1)
                        {
                            music[1].UnPause();
                        }

                    }
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
                    for (int i = 0; i < objects_to_hide_when_paused.Length; i++)
                    {
                        objects_to_hide_when_paused[i].SetActive(true);
                    }
                    battery_icon.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    blacknened_background.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    lights.SetActive(true);
                    gray_quad_for_pause.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    pause_text.gameObject.GetComponent<Text>().enabled = false;
                    continue_text.gameObject.GetComponent<Text>().enabled = false;
                    return_text.gameObject.GetComponent<Text>().enabled = false;
                    if (changed == false)
                    {
                        if (minutes == 8 && seconds == 0)
                        {
                            player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                            changed = true;
                        }
                        if (minutes == 4 && seconds == 0)
                        {
                            player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                            changed = true;
                        }
                    }
                    if (changed == true)
                    {
                        if (minutes == 6 && seconds == 0)
                        {
                            player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                            changed = false;
                        }
                        if (minutes == 2 && seconds == 0)
                        {
                            player.gameObject.GetComponent<CharController>().Decrease_number_of_cells();
                            changed = false;
                        }
                    }
                    if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() == 0 && run_out_of_cells == false)
                    {
                        if (player.gameObject.GetComponent<CharController>().Get_if_dead_by_enemy() == false)
                        {
                            player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
                            foreach (GameObject child in enemy)
                            {
                                child.gameObject.GetComponent<EnemyController>().Reset_number_of_hits();
                            }
                            run_out_of_cells = true;
                        }
                    }
                    if (player.gameObject.GetComponent<CharController>().Get_if_go_to_retry()==true&&go_to_retry==false)
                    {  
                        ManagerKeeper.Decrease_number_of_tries();
                       // Debug.Log("number is aaaaaaaaaaaaa " + ManagerKeeper.Get_number_of_tries_availables());
                        player.gameObject.GetComponent<CharController>().Set_if_go_to_retry(false);
                        go_to_retry = true;
                    } 
                    if(go_to_retry==true)
					{
                        timer_to_restart_level += Time.deltaTime;
                        if (start_music == true)
                        {
                            music[song_number].volume -= .05f * Time.deltaTime;
                            if (music[song_number].volume < 0)
                            {
                                music[song_number].Stop();
                            }
                        }
                        if (timer_to_restart_level > 3f)
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                fader.SetActive(true);
                            }
                            if(fader.gameObject.GetComponent<FaderScript>().Return_animation_complete()==true)
							{
                                {
                                    SceneManager.LoadScene("Game_Over_Scene");
                                }
                            }
                        }
                    }

                    if (to_main_menu == true)
                    {
                        music[song_number].Stop();
                        gray_quad_for_pause.gameObject.GetComponent<MeshRenderer>().enabled = true;
                        foreach (GameObject child in enemy)
                        {
                            if (child != null)
                            {
                                child.gameObject.SetActive(false);
                            }
                        }
                        fader.SetActive(true);
                        if (fader.gameObject.GetComponent<FaderScript>().Return_animation_complete() == true)
                        {
                            SceneManager.LoadScene("MainMenu");
                        }
                    }
                }
            }
            else if (time_counter_script_inside <= 0 && out_of_time == false)
            {
                player.gameObject.GetComponent<CharController>().Set_if_is_dead_zone_or_dead(false);
                out_of_time = true;
                if (out_of_time == true && player.gameObject.GetComponent<CharController>().Return_number_of_lifes() > 0)
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
                if (out_of_time == true && player.gameObject.GetComponent<CharController>().Return_number_of_lifes() == 0)
                {
                    time_counter_script_inside = 0;
                    ManagerKeeper.Decrease_number_of_tries();
                    //Debug.Log(ManagerKeeper.Get_number_of_tries_availables());
                }
            }   
        }
        else
		{
            timer_to_restart_level += Time.deltaTime;
            if (start_music == true)
            {
                music[song_number].volume-=.05f*Time.deltaTime;
                if(music[song_number].volume<0)
				{
                    music[song_number].Stop();
				}
            }
            if (timer_to_restart_level > 3f)
            {
                for (int i = 0; i < 1; i++)
                {
                    fader.SetActive(true);
                }
                if (fader.gameObject.GetComponent<FaderScript>().Return_animation_complete() == true)
                {
                    {
                        SceneManager.LoadScene("Game_Over_Scene_Final");
                    }
                }
            }
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
    public bool Return_if_paused()
	{
        return paused;
	}
    public void Set_volume_down(bool set_to_zero)
	{
        music_to_zero = set_to_zero;
        if (music_to_zero == true)
        {
            music[song_number].volume -= 0.05f * Time.deltaTime;
        }
		else
		{
            music[song_number].volume -= 0.05f * Time.deltaTime;
            if(music[song_number].volume<0.03f)
			{
                music[song_number].volume=0.03f;
			}
        }
	}
}