using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TransitionSceneController : MonoBehaviour
{
    private float timer;
    private bool start_timer;
    public GameObject[]screen_text;
    public bool is_press_text;
    private Color32 select_color;
    private bool to_main_menu;
    public bool is_game_over_scene;
    void Start()
    {
        timer = 0;
        start_timer = false;
        to_main_menu = false;
        select_color = new Color32(72, 58, 176, 255);
    }
    void Update()
    {
        if (is_game_over_scene == false)
        {
            if (screen_text[1].gameObject.GetComponent<TextEventsController>().Return_if_start_timer() == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        screen_text[0].gameObject.GetComponent<Animator>().Play("TextControllerOut");
                        screen_text[1].gameObject.GetComponent<Animator>().Play("PressTextOut");
                    }
                }
            }
        }
        else
        {
            if (screen_text[2].gameObject.GetComponent<TextEventsController>().Return_if_start_timer() == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                       
                        screen_text[0].gameObject.GetComponent<Animator>().Play("GameOverFadeOut");
                        screen_text[1].gameObject.GetComponent<Animator>().Play("PressTextOutInBlue");
                        screen_text[2].gameObject.GetComponent<Animator>().Play("ToMainMenuOut");
                       
                    }
                    if (Input.GetKeyUp(KeyCode.Escape))
                    {
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
            SceneManager.LoadScene("Main_Menu");
            //to main menu, falta crear scene y testear
		}
    }
}
