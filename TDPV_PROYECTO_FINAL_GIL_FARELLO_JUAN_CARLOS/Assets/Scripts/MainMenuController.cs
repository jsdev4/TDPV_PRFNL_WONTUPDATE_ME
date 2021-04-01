
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    private int screen_number;
    private int option;
    private int option_inside;
    private float timer;
    private Color32 unselect_color;
    private Color32 select_color;
    public Text[] screen_text;
    public Text[] screen_text_inside;
    public GameObject[] screen;
    public GameObject fader;
    public float smoothTime;
    private Vector3 velocity = new Vector3(2,0,0);
    private Vector3 velocity01 = new Vector3(-2, 0, 0);
    private bool can_press_key;
    private bool key_pressed;
    private Vector3 targetPosition;
    private Vector3 targetPosition01;
    private Vector3 targetPosition02;
    private Vector3 targetPosition03;
    private Vector3 targetPosition04;
    public AudioSource[] interface_sound;
    void Start()
    {
        screen_number = 0;
        option = 0;
        option_inside = 0;
        timer = 0;
        select_color = new Color32(116, 100, 168, 255);
        unselect_color = new Color32(214, 5, 127, 255);
        key_pressed = false;
        can_press_key = true;
        targetPosition =screen[1].gameObject.GetComponent<RectTransform>().position;
        targetPosition01 = screen[0].gameObject.GetComponent<RectTransform>().position;
        targetPosition02= screen[3].gameObject.GetComponent<RectTransform>().position;
        targetPosition03 = screen[1].gameObject.GetComponent<RectTransform>().position;
        targetPosition04 = screen[2].gameObject.GetComponent<RectTransform>().position;

    }

    void Update()
    {   
        //first layer of menu screens
        if (screen_number == 0)//start game
        {
            if (option == 0)
            {
                screen_text[0].gameObject.GetComponent<Text>().color = select_color;
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                {
                    interface_sound[0].Play();
                    option = 1;
                    screen_text[0].gameObject.GetComponent<Text>().color = unselect_color;
                }
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    interface_sound[2].Play();
                    key_pressed = true;
                }
                if (key_pressed == true)
                {
                    if (screen[1].gameObject.GetComponent<RectTransform>().position != targetPosition01)
                    {
                        screen[1].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[1].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity, smoothTime,4);
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition02, ref velocity, smoothTime,4);
                    }
                    if (screen[1].gameObject.GetComponent<RectTransform>().position == targetPosition01)
                    {
                        screen[0].SetActive(false);
                        option = 5;
                        key_pressed = false;
                    }
                }
            }
            if (option == 1)//options
            {
                timer += Time.deltaTime;
                screen_text[1].gameObject.GetComponent<Text>().color = select_color;
                if (timer > .2f)
                {
                    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                    {
                        interface_sound[0].Play();
                        option = 0;
                        timer = 0;
                        screen_text[1].gameObject.GetComponent<Text>().color = unselect_color;
                    }
                    if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                    {
                        interface_sound[0].Play();
                        option = 2;
                        timer = 0;
                        screen_text[1].gameObject.GetComponent<Text>().color = unselect_color;
                    }
                }
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    interface_sound[2].Play();
                    screen[2].SetActive(true);
                    key_pressed = true;  
                }
                if (key_pressed == true)
                { 
                    if (screen[2].gameObject.GetComponent<RectTransform>().position != targetPosition01)
                    {
                        screen[2].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[2].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity, smoothTime,4);
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition02, ref velocity, smoothTime,4);
                    }
                    if (screen[2].gameObject.GetComponent<RectTransform>().position == targetPosition01)
                    {
                        screen[0].SetActive(false);
                        option = 6;
                        key_pressed = false;
                    }
                } 
            }
            if (option == 2)//quit
            {
                timer += Time.deltaTime;
                screen_text[2].gameObject.GetComponent<Text>().color = select_color;
                if (timer > .2f)
                {
                    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                    {
                        interface_sound[0].Play();
                        timer = 0;
                        option = 1;
                        screen_text[2].gameObject.GetComponent<Text>().color = unselect_color;
                    }
                    if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                    {
                        interface_sound[0].Play();
                        timer = 0;
                        option = 3;
                        screen_text[2].gameObject.GetComponent<Text>().color = unselect_color;
                    }
                }
                if(Input.GetKeyUp(KeyCode.Return))
				{
                    key_pressed = true;
                    interface_sound[2].Play();    
                }
                if(key_pressed==true)
				{
                    if (screen[3].gameObject.GetComponent<RectTransform>().position != targetPosition01)
                    {
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition, ref velocity, smoothTime,4);
                        screen[3].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[3].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity, smoothTime,4);
                    }
                    if (screen[3].gameObject.GetComponent<RectTransform>().position == targetPosition01)
                    {
                        screen[0].gameObject.SetActive(false);
                        option = 4;
                        key_pressed = false;
                    }
                }
            }
            if (option == 3)//credits
            {  
                screen_text[3].gameObject.GetComponent<Text>().color = select_color;
                if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    interface_sound[0].Play();
                    option = 2;
                    screen_text[3].gameObject.GetComponent<Text>().color = unselect_color;
                }
                if(Input.GetKeyUp(KeyCode.Return))
				{
                    interface_sound[2].Play();
                    key_pressed = true;
				}
                if(key_pressed==true)
				{
                    screen[4].SetActive(true);
                    if(screen[4].gameObject.GetComponent<RectTransform>().transform.position!=targetPosition01)
					{
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition02, ref velocity, smoothTime,4);
                        screen[4].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[4].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity, smoothTime,4);
                    }
                    if (screen[4].gameObject.GetComponent<RectTransform>().transform.position == targetPosition01)
                    {
                        screen[0].SetActive(false);
                        option = 7;
                        key_pressed = false;
                    }
                }
            }
            //-------------------------------------------------------------------
            //second layer
            //sub menu quit game
            if(option==4)
            { 
                if (option_inside == 0)
                {
                    screen_text_inside[0].gameObject.GetComponent<Text>().color = select_color;
                    if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                    {
                        interface_sound[0].Play();
                        option_inside = 1;
                        //Debug.Log("options is 1 now");
                        screen_text_inside[0].gameObject.GetComponent<Text>().color = unselect_color;
                    }
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        Application.Quit();
                        //Debug.Log("Key");
                    }
                }
                if (option_inside == 1)
                {
                    screen_text_inside[1].gameObject.GetComponent<Text>().color = select_color;
                    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                    {
                        interface_sound[0].Play();
                        option_inside = 0;
                       // Debug.Log("options is0 now");
                        screen_text_inside[1].gameObject.GetComponent<Text>().color = unselect_color;
                    }
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        interface_sound[1].Play();
                        key_pressed = true;
                    }
                    if (key_pressed == true)
                    {
                        if (screen[3].gameObject.GetComponent<RectTransform>().position != targetPosition02)
                        {
                            screen[0].SetActive(true);
                            screen[0].gameObject.GetComponent<RectTransform>().position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity, smoothTime,4);
                            screen[3].gameObject.GetComponent<RectTransform>().position = Vector3.SmoothDamp(screen[3].gameObject.GetComponent<RectTransform>().transform.position, targetPosition02, ref velocity, smoothTime,4);
                        }
                        if (screen[3].gameObject.GetComponent<RectTransform>().position == targetPosition02)
                        {
                            option = 2;
                            key_pressed = false;
                        }
                    }
                }
            }
            if(option==5)//sub menu start game
			{
                if(Input.GetKeyUp(KeyCode.Return))
				{
                    interface_sound[2].Play();
                    can_press_key = false;
                    fader.SetActive(true);
                    fader.gameObject.GetComponent<Animator>().Play("Fade_in_blue");   
				}
                if (fader.gameObject.GetComponent<FaderScript>().Return_animation_complete() == true)
                {
                    SceneManager.LoadScene("Level_01_Depo");
                    //Debug.Log("next scene is here");
                }
                if (can_press_key==true&&Input.GetKeyUp(KeyCode.Escape))
                {
                    interface_sound[1].Play();
                    key_pressed = true;
                }
                if(key_pressed==true)
				{
                    if(screen[1].gameObject.GetComponent<RectTransform>().transform.position!=targetPosition03)
					{
                        screen[0].SetActive(true);
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity01, smoothTime,4);
                        screen[1].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[1].gameObject.GetComponent<RectTransform>().transform.position, targetPosition03, ref velocity01, smoothTime,4);
                    }
                    if (screen[1].gameObject.GetComponent<RectTransform>().transform.position == targetPosition03)
                    {
                        option = 0;
                        key_pressed = false;
                    }
                }
            }
            if (option == 6)//sub menu options
            {
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    interface_sound[1].Play();
                    screen[0].SetActive(true);
                    key_pressed = true;
                }
                if (key_pressed == true)
                {
                    if (screen[2].gameObject.GetComponent<RectTransform>().position != targetPosition04)
                    {
                        
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity01, smoothTime,4);
                        screen[2].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[2].gameObject.GetComponent<RectTransform>().transform.position, targetPosition04, ref velocity01, smoothTime,4);
                    }
                    if (screen[2].gameObject.GetComponent<RectTransform>().transform.position == targetPosition04)
                    {
                        option =1;     
                        screen[2].SetActive(false);
                        key_pressed = false;
                    }
                }
            }
            if(option==7)//sub menu credits
			{
                if(Input.GetKeyUp(KeyCode.Return))
				{
                    interface_sound[1].Play();
                    key_pressed = true;
				}
                if (key_pressed == true)
                {
                    if (screen[4].gameObject.GetComponent<RectTransform>().position != targetPosition)
                    {
                        screen[0].SetActive(true);
                        screen[0].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[0].gameObject.GetComponent<RectTransform>().transform.position, targetPosition01, ref velocity01, smoothTime,4);
                        screen[4].gameObject.GetComponent<RectTransform>().transform.position = Vector3.SmoothDamp(screen[4].gameObject.GetComponent<RectTransform>().transform.position, targetPosition, ref velocity01, smoothTime,4);
                    }
                    if (screen[4].gameObject.GetComponent<RectTransform>().transform.position == targetPosition)
                    {
                        option = 3;
                        screen[4].SetActive(false);
                        key_pressed = false;
                    }
                }
            }
        }
    }
}
