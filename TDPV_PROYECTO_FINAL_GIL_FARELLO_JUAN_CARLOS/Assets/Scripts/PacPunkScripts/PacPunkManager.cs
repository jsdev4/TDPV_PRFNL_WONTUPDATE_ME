using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PacPunkManager : MonoBehaviour
{
    private float timer;
    public float delay_to_pause;
    public float delay_to_restart;
    private float timer_to_restart;
    private float timer_for_enemies_on_start_level;
    private float timer_to_back_to_level03;
    public float speed_for_script;
    public float max_time;
    public float critical_time;
    private int icons_collected;
    private bool special_icon_collected;
    private bool player_was_hitted;
    private bool game_started;
    private bool start_timer;
    private int numberOfTaggedObjects;
    private int numberOfSpecialTaggedObject;
    private int random_respawn;
    private int score;
    public GameObject[] enemy_ghost;
    public GameObject player;
    public GameObject menu_screen;
    public GameObject game_completed_screen;
    public GameObject game_over_screen;
    public GameObject fader;
    public GameObject life_icon;
    public GameObject score_text;
    public Text screen_score;
    private string score_string;
    void Awake()
    {
        fader.SetActive(true);
        fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
    }
    void Start()
    {
        numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("WaitingIconBall").Length;
        numberOfSpecialTaggedObject = GameObject.FindGameObjectsWithTag("SpecialIcon").Length;
        timer = 0;
        timer_to_restart = 0;
        timer_for_enemies_on_start_level = 0;
        timer_to_back_to_level03 = 0;
        game_started = false;
        special_icon_collected = false;
        player_was_hitted = false;
        start_timer = false;
        icons_collected = 0;
        random_respawn = 0;
        score = 0;
        Debug.Log(numberOfTaggedObjects);
    }
    void Update()
    {
        if(game_started==false)
        {
            if (Input.GetKeyUp(KeyCode.Return))
			{
                fader.SetActive(true);
            }
            if(fader.gameObject.GetComponent<FaderScript>().Return_animation_complete()==true)
			{
                menu_screen.SetActive(false);
                fader.SetActive(true);
                fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();      
                game_started = true;
            }
        }
        if (game_started == true)
        {
            life_icon.SetActive(true);
            score_text.SetActive(true);
            timer_for_enemies_on_start_level += Time.deltaTime;
            if(timer_for_enemies_on_start_level>=2f)
			{
                for (int i = 0; i < 4; i++)
                {
                    enemy_ghost[i].SetActive(true);
                }
                timer_for_enemies_on_start_level = 0;
            }
            score_string ="Score: "+ score.ToString();
            screen_score.text = score_string; 
            if (special_icon_collected == true)
            {
                timer += Time.deltaTime;
                if (timer >= critical_time)
                {

                }
                if (timer >= max_time)
                {
                    Debug.Log("Special icon is out");
                    for (int i = 0; i < 4; i++)
                    {
                        if (enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Return_if_enemy_hit_the_player() == true)
                        {
                            enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Set_if_player_can_be_hitted();
                        }
                    }
                    special_icon_collected = false;
                    timer = 0;
                }
            }
            if (icons_collected == numberOfTaggedObjects + numberOfSpecialTaggedObject)
            {
                Keep_characters_static();
                life_icon.SetActive(false);
                score_text.SetActive(false);
                game_completed_screen.SetActive(true);
                ManagerKeeper.Set_if_mini_game_was_completed(true);
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    random_respawn = Random.Range(0, 5);
                    Debug.Log(random_respawn);
                    start_timer = true;
                }
                if (start_timer == true)
                {
                    ManagerKeeper.Set_respawn_point(random_respawn);
                    SceneManager.LoadScene("Level_03_Lab");
                }
            }
            if (icons_collected != numberOfTaggedObjects + numberOfSpecialTaggedObject)
            {
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    Keep_characters_static();
                    start_timer = true;
                }
                if (start_timer == true)
                {
                    fader.SetActive(true);
                    ManagerKeeper.Set_if_mini_game_was_completed(false);
                    timer_to_back_to_level03 += Time.deltaTime;
                    if (timer_to_back_to_level03 >=3f&&timer_to_back_to_level03<=5f)
                    {
                        fader.SetActive(false);
                        life_icon.SetActive(false);
                        score_text.SetActive(false);
                        game_over_screen.SetActive(true);
                    }
                    if (timer_to_back_to_level03 >5)
                    {
                        SceneManager.LoadScene("Level_03_Lab");
                    }
                }
            }
            if (player_was_hitted == true && player.gameObject.GetComponent<CharControllerForPacPunk>().Return_number_of_lifes() >= 1)
            {
                Freeze_characters_stuff();
                timer_to_restart += Time.deltaTime;
                if (timer_to_restart > delay_to_pause && timer_to_restart < delay_to_restart)
                {
                    Restart_characters_stuff();
                    player.gameObject.GetComponent<CharControllerForPacPunk>().Decrease_life();
                    timer_to_restart = 0;
                }
                player_was_hitted = false;
            }
           if (player.gameObject.GetComponent<CharControllerForPacPunk>().Return_number_of_lifes() == 0)
            {
                Keep_characters_static();
                fader.SetActive(true);
                timer_to_back_to_level03 += Time.deltaTime;
                if (timer_to_back_to_level03 >= 3f && timer_to_back_to_level03 <= 5f)
                {
                    fader.SetActive(false);
                    life_icon.SetActive(false);
                    score_text.SetActive(false);
                    game_over_screen.SetActive(true);
                }
                if (timer_to_back_to_level03 > 5)
                {
                    SceneManager.LoadScene("Level_03_Lab");
                }
            }
        }
    }
    public void Increase_icons_collected()
	{
        icons_collected += 1;
        score += 10;
       // Debug.Log(icons_collected);
	}
    public void Increase_special_icon_collected()
	{
        icons_collected += 1;
        score += 10;
       // Debug.Log("special icon is collected");
        special_icon_collected = true;
	}
    public void Increase_enemy_hitted()
	{
        score += 50;
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
    private void Freeze_characters_stuff()
	{
        player.gameObject.GetComponent<CharControllerForPacPunk>().Set_if_player_is_alive(false, false);
        for (int i = 0; i < 4; i++)
        {
            enemy_ghost[i].gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
    private void Restart_characters_stuff()
	{
        for (int i = 0; i < 4; i++)
        {
            enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Set_initial_pos();
            enemy_ghost[i].gameObject.GetComponent<enemyGhostController>().Set_if_player_can_be_hitted();
            enemy_ghost[i].gameObject.GetComponent<NavMeshAgent>().speed = speed_for_script;
        }
        player.gameObject.GetComponent<CharControllerForPacPunk>().Set_if_player_is_alive(true, true);
        player.gameObject.GetComponent<CharControllerForPacPunk>().Set_initial_pos();
    }
    private void Keep_characters_static()
	{
        for (int i = 0; i < 4; i++)
        {
            enemy_ghost[i].SetActive(false);
        }
        player.gameObject.GetComponent<CharControllerForPacPunk>().Set_if_player_is_alive(false, true);
    }
}
