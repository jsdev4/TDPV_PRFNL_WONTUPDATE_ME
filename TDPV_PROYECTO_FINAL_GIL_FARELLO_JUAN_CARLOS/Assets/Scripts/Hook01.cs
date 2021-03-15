using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Hook01 : MonoBehaviour
{
    private bool direction;
    public int hook_number;
    private Transform trnsfrm;
    public GameObject player;
    private bool player_on_it;
    public GameObject[] hooks;
    public GameObject[] PathNode;
    public GameObject hook;
    public float MoveSpeed;
    private float firstPosZ_player;
    float Timer;
    static Vector3 CurrentPositionHolder;
    public int CurrentNode;
    private Vector3 startPosition;
    private float delay;
    public float max_time_to_reset;
    public GameObject[] level_limits_for_deactivation;
    private Rigidbody rb;
    void Start()//////////////////////////////////////////modificar y poner una caja!
    {
       
        firstPosZ_player = player.gameObject.GetComponent<Transform>().position.z;
        direction = true;
        trnsfrm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 currentPos = rb.position;
        Vector3 currentPosfixed = new Vector3(currentPos.x, currentPos.y - 2f, currentPos.z);
        Vector3 newPlayerPos = new Vector3(player.gameObject.GetComponent<Rigidbody>().position.x, player.gameObject.GetComponent<Rigidbody>().position.y, firstPosZ_player);
        if (direction == true)
        {
            Timer += Time.fixedDeltaTime * MoveSpeed;
            if (hook.gameObject.GetComponent<Rigidbody>().position != CurrentPositionHolder)
            {
                hook.gameObject.GetComponent<Rigidbody>().position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1 * Timer);
            }
            else
            {
                if (CurrentNode < PathNode.Length - 1)
                {
                    CurrentNode++;
                    CheckNode();
                }
                if (CurrentNode == PathNode.Length - 1)
                {
                    delay += Time.fixedDeltaTime;
                    if (delay >= max_time_to_reset)
                    {
                        CurrentNode = -1;
                        delay = 0;
                    }
                }
            }
        }
        if (hook_number==2&&player_on_it == true)
        {
            hooks[0].SetActive(false);
            hooks[1].SetActive(false);
            hooks[3].SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                level_limits_for_deactivation[i].gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            

            player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(true);
            player.gameObject.GetComponent<Rigidbody>().MovePosition(currentPosfixed);
            if (CurrentNode > 0 && CurrentNode < 2)
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    player_on_it = false;
                }
                if (Input.GetKeyUp(KeyCode.Space) && player.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == true)
                {
                    player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 7.5f, ForceMode.Impulse);
                    player_on_it = false;
                }
                if (Input.GetKeyUp(KeyCode.Space) && player.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == false)
                {
                    player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 7.5f, ForceMode.Impulse);
                    player_on_it = false;
                }
            }
            if (CurrentNode >3 && CurrentNode < 6)
            {
                if (player.gameObject.GetComponent<Transform>().position.z < 1.5f && player.gameObject.GetComponent<Transform>().position.z > -1.5f)
                {            
                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        player_on_it = false;
                        player.gameObject.GetComponent<Transform>().position = newPlayerPos;
                      /*  player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        player.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
                        player.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY; */                    
                    }
                }
            }
        }
        if (hook_number==2&&player_on_it == false)
        {
            hooks[0].SetActive(true);
            hooks[1].SetActive(true);
            hooks[3].SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                level_limits_for_deactivation[i].gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            player_on_it = true;
        }
    }
    void CheckNode()
    {
        Timer = 0;
        startPosition = transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].gameObject.GetComponent<Transform>().position;
    }
}
