using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharControllerForPacPunk : MonoBehaviour
{
    private bool is_moving_for_sound_play;
    public bool change_music;
    public float speed;
    public float jump_speed;
    private bool can_move;
    private bool is_alive;
    private bool moving_up;
    private bool moving_down;
    private int lifes;
    private Vector3 firstPos;
    private Transform trnsfrm;
    public GameObject quad;
    public GameObject manager;
    public AudioSource[] player_sound;

    void Start()
    {
        is_moving_for_sound_play = false;
        lifes = 3;
        trnsfrm = GetComponent<Transform>();
        can_move = true;
        is_alive = true;
        moving_up = false;
        moving_down = false;
        firstPos = trnsfrm.position;
        player_sound[0].enabled = false;
        player_sound[1].enabled = false;
    }
    void Update()
    {
        if (manager.gameObject.GetComponent<PacPunkManager>().Return_if_game_started() == true)
        {
            if (can_move == true)
            {
                if (is_alive == true)
                {
                    quad.gameObject.GetComponent<Animator>().Play("pacpunkIdle");
                    float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                    float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
                    transform.Translate(translationX, 0, translation);
                    if (Input.GetKey(KeyCode.A))
                    {
                        is_moving_for_sound_play = true;
                        quad.gameObject.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        is_moving_for_sound_play = true;
                        quad.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                    }
                    if (Input.GetKey(KeyCode.W))
                    {
                        is_moving_for_sound_play = true;
                        moving_up = true;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        is_moving_for_sound_play = true;
                        moving_down = true;
                    }
                    if (Input.GetKeyUp(KeyCode.W))
                    {
                        is_moving_for_sound_play = false;
                        moving_up = false;
                    }
                    if (Input.GetKeyUp(KeyCode.S))
                    {
                        is_moving_for_sound_play = false;
                        moving_down = false;
                    }
                    if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.D)))
                    {
                        is_moving_for_sound_play = false;
                    }
                    if (is_moving_for_sound_play == true)
                    {
                        if (change_music == false)
                        {
                            player_sound[0].enabled = true;
                            player_sound[1].enabled =false;
                            player_sound[0].volume = .2f;
                        }
                        if (change_music == true)
                        {
                            player_sound[1].enabled = true;
                            player_sound[0].enabled =false;
                            player_sound[1].volume = .6f;
                        }
                    }
                    if (is_moving_for_sound_play == false)
                    {
                        if (change_music == false)
                        {
                            player_sound[1].enabled =false;
                            player_sound[0].enabled = true;
                            player_sound[0].volume = 0.1f;
                        }
                        if (change_music == true)
                        {
                            player_sound[1].enabled = true;
                            player_sound[0].enabled = false;
                            player_sound[1].volume = 0.2f;
                        }
                    }
                }
            }
            if (can_move == false)
            {
                if (is_alive == false)
                {
                    player_sound[0].enabled = false;
                    player_sound[1].enabled = false;
                    quad.gameObject.GetComponent<Animator>().Play("pacpunkdying");
                }
            }
            if (can_move == false)
            {
                if (is_alive == true)
                {
                    player_sound[0].enabled =false;
                    player_sound[1].enabled = false;
                    quad.gameObject.GetComponent<Animator>().Play("pacpunkIdle");
                }
            }
        }
    }
    public void Set_if_player_is_alive(bool move, bool alive)
    {
        can_move = move;
        is_alive = alive;
    }
    public void Set_initial_pos()
    {
        trnsfrm.position = firstPos;
    }
    public int Return_number_of_lifes()
    {
        return lifes;
    }
    public void Decrease_life()
    {
        lifes -= 1;
        Debug.Log("life is" + lifes);
    }
    public bool Set_moving_up()
    {
        return moving_up;
    }
    public void Set_music_change(bool music)
    {
        change_music = music;
    }
    public void Set_stop_music()
	{
       for (int i=0;i<player_sound.Length;i++)
		{
            player_sound[i].enabled = false;
		}
	}
	
}
