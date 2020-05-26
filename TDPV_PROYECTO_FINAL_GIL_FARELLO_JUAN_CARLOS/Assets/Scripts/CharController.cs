using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{
    public float speed;
    public float jump_speed;
    
    private Vector3 rotation_sprite;
    bool on_ground;
    private Rigidbody rb;
    private bool is_moving;
    private bool is_jumping;
    private bool is_alive;
    private bool can_jump;
    private bool has_respawned;
    private bool is_interacting;
    private bool is_light_on;
    private bool can_move;
    public int lifes;
    private int respawn_point;
    private float delay_for_interacting;
    private float delay_for_respawn;
    private float number_of_cells;

    public GameObject quad;
    public GameObject[] respawn;
    public GameObject[] low_beam_light;
    public GameObject manager;
    void Start()
    {
       /// number_of_cells = 5;
        respawn_point = 0;
        delay_for_interacting = 0;
        delay_for_respawn = 0;
        has_respawned = false;
        rb = GetComponent<Rigidbody>();
        is_moving = false;
        is_jumping = false;
        is_alive = true;
        can_jump = false;
        is_interacting = false;
        is_light_on = false;
        can_move = true;
    }
    void Update()
    {
        Vector3 translation = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0);
        if (can_move == true)
        {
            if (is_alive == true)
            {
                rb.MovePosition(transform.position + translation * speed * Time.deltaTime);
                if (Input.GetKey(KeyCode.A))
                {
                    is_moving = true;
                    rotation_sprite = new Vector3(-1, 1, 1);
                    transform.localScale = rotation_sprite;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    is_moving = true;
                    rotation_sprite = new Vector3(1, 1, 1);
                    transform.localScale = rotation_sprite;
                }
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                {
                    is_moving = false;
                }
                ///Light function--------------------------------
                if (Input.GetKeyUp(KeyCode.L))
                {
                    is_light_on = !is_light_on;
                }
                ///endl light function----------------------------
                ///
                if(Input.GetKeyUp(KeyCode.I))
                {
                    Increase_number_of_cells();
                }
                if (is_moving == false && is_jumping == false)
                {
                    if (is_interacting == true)
                    {
                        delay_for_interacting += Time.deltaTime;
                        quad.gameObject.GetComponent<Animator>().Play("InteractingPlayer");
                        if (delay_for_interacting >= 1.2f)
                        {
                            delay_for_interacting = 0;
                            is_interacting = false;
                        }
                    }
                    if (is_interacting == false)
                    {
                        quad.gameObject.GetComponent<Animator>().Play("IdlePlayer");
                    }
                }
                if (is_moving == true && is_jumping == false)
                {
                    quad.gameObject.GetComponent<Animator>().Play("RunningPlayer");
                }
                if (can_jump == false)
                {
                    if (is_jumping == true)
                    {
                        quad.gameObject.GetComponent<Animator>().Play("JumpPlayer");
                    }
                }
                if (on_ground == true)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        is_jumping = true;
                        rb.AddForce(Vector3.up * jump_speed, ForceMode.Impulse);
                    }
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        is_jumping = true;
                        on_ground = false;
                    }
                }
            }
            if (is_alive == false)
            {
                is_light_on = false;
                quad.gameObject.GetComponent<Animator>().Play("DyingPlayer");
                if (lifes >= 1 && has_respawned == false)
                {
                    delay_for_respawn += Time.deltaTime;
                    if (delay_for_respawn >= 3)
                    {
                        delay_for_respawn = 0;
                        is_moving = false;
                        has_respawned = true;
                        is_alive = true;
                        number_of_cells = manager.gameObject.GetComponent<ManagerScript>().Get_cells_for_timer();
                    }
                }
            }
            if (has_respawned == true && respawn_point == 0)
            {
                transform.position = respawn[0].gameObject.GetComponent<Transform>().position;
                transform.Translate(0, 0, -0.4f);
                has_respawned = false;
            }
            if (has_respawned == true && respawn_point == 1)
            {
                transform.position = respawn[1].gameObject.GetComponent<Transform>().position;
                transform.Translate(0, 0, -0.4f);
                has_respawned = false;
            }
            if (has_respawned == true && respawn_point == 2)
            {
                transform.position = respawn[2].gameObject.GetComponent<Transform>().position;
                transform.Translate(0, 0, -0.4f);
                has_respawned = false;
            }
            if (is_light_on == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    low_beam_light[i].gameObject.GetComponent<Light>().enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    low_beam_light[i].gameObject.GetComponent<Light>().enabled = false;
                }
            }
        }
    }
    public void Set_if_is_dead_zone_or_dead(bool alv)
    {
        is_alive = alv;
        lifes -= 1;
        Debug.Log("lifes :" + lifes);
    }
    public bool Player_is_alive()
    {
        return is_alive;
    }
    public void Can_jump_on_elevator(bool jump)
    {
        can_jump = jump;
    }
    public void Decrease_one_life()
    {
        lifes -= 1;
        Debug.Log("lifes :" + lifes);
    }
    public void Set_respawn_point(int rspwn)
    {
        respawn_point = rspwn;
        is_interacting = true;
    }
    public void Set_if_is_interacting(bool doing_stuff)
    {
        is_interacting = doing_stuff;
    }
    public bool Return_if_is_on_ground()
    {
        return on_ground;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag("ground")||collision.collider.CompareTag("Elevator")||collision.collider.CompareTag("Box")||collision.collider.CompareTag("MetallicStructure"))
        {
            on_ground = true;
            is_jumping = false;
        }
    }
    public void Set_if_is_on_the_hook()
    {
        speed = 0;
        is_interacting = false;
    }
    public void Decrease_number_of_cells()
    {
        number_of_cells -= 1;
        Debug.Log(number_of_cells);
    }
    public void Set_number_of_cells(int cells)
    {
        number_of_cells = cells;
    }
    public float Return_number_of_cells()
    {
        return number_of_cells;
    }
    public void Set_if_player_can_move(bool _can_move)
    {
        can_move = _can_move;
    }
    public int Return_number_of_lifes()
    {
        return lifes;
    }
    private void Increase_number_of_cells()
    {
        number_of_cells+=1;
    }
}

