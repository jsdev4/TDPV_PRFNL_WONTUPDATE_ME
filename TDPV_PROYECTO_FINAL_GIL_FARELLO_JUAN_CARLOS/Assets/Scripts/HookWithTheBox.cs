﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookWithTheBox : MonoBehaviour
{
   
    public float MoveSpeed;
    private float Timer;
    private float delay;
    public float max_time_to_reset;
    static Vector3 CurrentPositionHolder;
    private Vector3 startPosition;
    public GameObject hook;
    public GameObject player;
    public GameObject[] PathNode;
    public GameObject manager;
    private AudioSource hook_rail_sound;
    public int CurrentNode;
    void Start()
    {
        hook_rail_sound = GetComponent<AudioSource>();
        hook_rail_sound.Play();
    }
    void Update()
    {
        if (manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false)
        {
            hook_rail_sound.enabled = true;
            Timer += Time.deltaTime * MoveSpeed;
            if (hook.gameObject.GetComponent<Transform>().position != CurrentPositionHolder)
            {
                hook.gameObject.GetComponent<Transform>().position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1 * Timer);
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
                    delay += Time.deltaTime;
                    if (delay >= max_time_to_reset)
                    {
                        CurrentNode = -1;
                        delay = 0;
                    }
                }
            }
        }
        else
		{
            hook_rail_sound.enabled = false;
		}
    }
    void CheckNode()
    {
        Timer = 0;
        startPosition = transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].gameObject.GetComponent<Transform>().position;
    }
    public int Get__nodes_id()
	{
        return CurrentNode;
	}
}
