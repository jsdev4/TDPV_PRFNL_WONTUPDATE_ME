
using UnityEngine;
using UnityEngine.AI;

public class enemyGhostController : MonoBehaviour
{
    private bool hit_the_player;
    private bool to_respawn;
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
        to_respawn = false;
        hit_the_player = false;
        quad_trnsfrm=GetComponentInChildren<Transform>();
        quad_animator = GetComponentInChildren<Animator>();
        ghost = GetComponent<NavMeshAgent>();
        box = GetComponent<BoxCollider>();
        firstPos = transform.position;
    }

    void FixedUpdate()
    {  
        quad_trnsfrm.LookAt(enemy_ghost_reference);
        float distance = Vector3.Distance(transform.position, player.gameObject.GetComponent<Transform>().position);
        if (pac_punk_manager.gameObject.GetComponent<PacPunkManager>().Get_if_special_icon_collected() == false)
        {
            player.gameObject.GetComponent<CharControllerForPacPunk>().Set_music_change(false);
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
            }
        }
            if (pac_punk_manager.gameObject.GetComponent<PacPunkManager>().Get_if_special_icon_collected() == true)
            {
            player.gameObject.GetComponent<CharControllerForPacPunk>().Set_music_change(true);
            if (hit_the_player == false)
                {
                    ghost.SetDestination(safeHouse.gameObject.GetComponent<Transform>().position);
                    quad_animator.Play("enemyghostIdlealerted");
                }
                if (hit_the_player == true)
                {
                pac_punk_manager.gameObject.GetComponent<PacPunkManager>().Increase_enemy_hitted();
                    box.enabled = false;
                    transform.position = safeHouse.gameObject.GetComponent<Transform>().position;
                    to_respawn = true;
                hit_the_player = false;
            }
            }
            if (to_respawn == true)
            {
                timer += Time.deltaTime;
                if (timer >= 5)
                {
                    box.enabled = true;
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
    public bool Return_if_enemy_hit_the_player()
	{
        return hit_the_player;
	}
    
}
