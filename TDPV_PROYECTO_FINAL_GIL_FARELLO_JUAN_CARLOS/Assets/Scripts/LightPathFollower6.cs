﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPathFollower6 : MonoBehaviour
{

	public GameObject[] PathNode;
	public GameObject pointlight;
	public float MoveSpeed;
	float Timer;
	static Vector3 CurrentPositionHolder;
	int CurrentNode;
	private Vector3 startPosition;
	private float delay;
	public float max_time_to_reset;
	private bool check_node;
	// Use this for initialization
	void Start()
	{
		delay = 0;
		Timer = 0;
		startPosition = pointlight.transform.position;
		CurrentPositionHolder = PathNode[CurrentNode].transform.position;
		
		//PathNode = GetComponentInChildren<>();
		//CheckNode();
	}

	public void CheckNode()
	{
		Timer = 0;
		startPosition = pointlight.transform.position;
		CurrentPositionHolder = PathNode[CurrentNode].transform.position;
		GetComponent<Light>().enabled = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (check_node == true)
		{
			GetComponent<Light>().enabled = true;
			Timer += Time.deltaTime * MoveSpeed;

			if (pointlight.transform.position != CurrentPositionHolder)
			{

				pointlight.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1 * Timer);

			}
			else
			{

				if (CurrentNode < PathNode.Length - 1)
				{

					CurrentNode++;
					CheckNode();
					if (CurrentNode == 0)
					{
						GetComponent<Light>().enabled = false;
					}
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
			GetComponent<Light>().enabled = false;
			CurrentPositionHolder = PathNode[0].transform.position;
			pointlight.transform.position = PathNode[0].transform.position;
			
		}
	}
	public void Set_checkNode(bool check)
	{
		check_node = check;
	}
}
