using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class enemyGhostController : MonoBehaviour
{
    private bool hit_the_player;
    private bool to_respawn;
    private bool can_enemy_move;
    private float timer;
    public float min_distance;
    private Vector3 firstPos;
    private NavMeshAgent ghost;
    private Transform quad_trnsfrm;
    public GameObject player;
    public GameObject safeHouse;
    public Transform enemy_ghost_reference;
    public GameObject pac_punk_manager;
    private Animator quad_animator;
    private BoxCollider box;
    void Start()
    {
        timer = 0;
        can_enemy_move = true;
        to_respawn = false;
        hit_the_player = false;
        quad_trnsfrm=GetComponentInChildren<Transform>();
        quad_animator = GetComponentInChildren<Animator>();
        ghost = GetComponent<NavMeshAgent>();
        box = GetComponent<BoxCollider>();
        firstPos = transform.position;
    }

    void Update()
    {
       
        quad_trnsfrm.LookAt(enemy_ghost_reference);
        float distance = Vector3.Distance(transform.position, player.gameObject.GetComponent<Transform>().position);
            if (pac_punk_manager.gameObject.GetComponent<PacPunkManager>().Get_if_special_icon_collected() == false)
            {

                if (hit_the_player == false)
                {
                    quad_animator.Play("enemyghostIdle");
                    if (distance < min_distance)
                    {

                        ghost.SetDestination(player.gameObject.GetComponent<Transform>().position);
                    }
                }
                if (hit_the_player == true)
                {
                    pac_punk_manager.gameObject.GetComponent<PacPunkManager>().Set_if_player_die();
                //sets enemy to zero speed for everyone
                //call to manager
                
               
                }
            }
            if (pac_punk_manager.gameObject.GetComponent<PacPunkManager>().Get_if_special_icon_collected() == true)
            {

                if (hit_the_player == false)
                {
                    ghost.SetDestination(safeHouse.gameObject.GetComponent<Transform>().position);
                    quad_animator.Play("enemyghostIdlealerted");
                }
                if (hit_the_player == true)
                {
                    box.enabled = false;
                    transform.position = safeHouse.gameObject.GetComponent<Transform>().position;
                    to_respawn = true;
                  
                }
            }
            if (to_respawn == true)
            {
                timer += Time.deltaTime;
                if (timer >= 5)
                {
                    box.enabled = true;

                hit_the_player = false;
                timer = 0;
                to_respawn = false;
            }
            }

    }
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
            hit_the_player = true;
		}
	}

    public void Set_initial_pos()
	{
        transform.position = firstPos;
	}
    public void Set_if_player_can_be_hitted()
	{
        hit_the_player = false;
	}
}
