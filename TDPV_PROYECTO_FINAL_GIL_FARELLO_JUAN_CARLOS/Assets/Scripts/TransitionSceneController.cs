using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TransitionSceneController : MonoBehaviour
{
    private float timer;
    private bool key_was_pressed;
    public GameObject[]screen_text;
    public bool is_press_text;
    public bool is_game_over_scene_final;
    private bool to_main_menu;
    public bool is_game_over_scene;
    public AudioSource[] interface_sound;
    void Start()
    {
        timer = 0;
        key_was_pressed = false;
        to_main_menu = false;
    }
    void Update()
    {
        if (is_game_over_scene == false)////code for transition scene
        {
            if (screen_text[1].gameObject.GetComponent<TextEventsController>().Return_if_start_timer() == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        interface_sound[0].Play();
                        key_was_pressed = true;
                        screen_text[0].gameObject.GetComponent<Animator>().Play("TextControllerOut");
                        screen_text[1].gameObject.GetComponent<Animator>().Play("PressTextOut");
                    }
                }
            }
        }
        if (is_game_over_scene_final == true)////code for game over final
        {
            if (screen_text[1].gameObject.GetComponent<TextEventsController>().Return_if_start_timer() == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    if (Input.GetKeyUp(KeyCode.Escape))
                    {
                        interface_sound[1].Play();
                        screen_text[0].gameObject.GetComponent<Animator>().Play("GameOverFadeOut");
                        screen_text[1].gameObject.GetComponent<Animator>().Play("ToMainMenuOutInBlue");
                        to_main_menu = true;
                    }
                }
            }
        }
        else if(is_game_over_scene==true&&is_game_over_scene_final==false)//code fot game over with retry
        {
            Debug.Log("tries are " + ManagerKeeper.Get_number_of_tries_availables());
            Debug.Log("number of reached level is " + ManagerKeeper.Get_number_of_reached_level());
            if (screen_text[1].gameObject.GetComponent<TextEventsController>().Return_if_start_timer() == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        interface_sound[0].Play();
                        to_main_menu = false;
                        screen_text[0].gameObject.GetComponent<Animator>().Play("GameOverFadeOut");
                        screen_text[1].gameObject.GetComponent<Animator>().Play("PressTextOutInBlue");
                        screen_text[2].gameObject.GetComponent<Animator>().Play("ToMainMenuOut");
                       
                    }
                    if (Input.GetKeyUp(KeyCode.Escape))
                    {
                        interface_sound[1].Play();
                        to_main_menu = true;
                        screen_text[0].gameObject.GetComponent<Animator>().Play("GameOverFadeOut");
                        screen_text[1].gameObject.GetComponent<Animator>().Play("PressTextFadeOut");
                        screen_text[2].gameObject.GetComponent<Animator>().Play("ToMainMenuOutInBlue");
                        ManagerKeeper.Reset_number_of_level();
                    }
                }
            }
        }
        if (screen_text[1].gameObject.GetComponent<TextEventsController>().Return_if_to_next_scene() == true && to_main_menu == false)
        {
            if (ManagerKeeper.Get_number_of_reached_level() == 0)
            {
                SceneManager.LoadScene("Level_01_Depo");
            }
            if (ManagerKeeper.Get_number_of_reached_level() == 1)
            {
                SceneManager.LoadScene("Level_02_Factory");
            }
            if (ManagerKeeper.Get_number_of_reached_level() == 2)
            {
                SceneManager.LoadScene("Level_03_Lab");
            }
            if (ManagerKeeper.Get_number_of_reached_level() == 3)
            {
                SceneManager.LoadScene("Level_04_Stereo_City");
            }
            if (ManagerKeeper.Get_number_of_reached_level() == 4)
            {
                SceneManager.LoadScene("Level_05_The_Outlands");
            }
            if (ManagerKeeper.Get_number_of_reached_level() == 5)
            {
                SceneManager.LoadScene("Final_Scene");
            }
        }
        if (screen_text[1].gameObject.GetComponent<TextEventsController>().Return_if_to_next_scene() == true && to_main_menu == true)
		{
            SceneManager.LoadScene("MainMenu");
		}
    }
    public bool Return_if_key_was_pressed()
	{
        return key_was_pressed;
	}
}
