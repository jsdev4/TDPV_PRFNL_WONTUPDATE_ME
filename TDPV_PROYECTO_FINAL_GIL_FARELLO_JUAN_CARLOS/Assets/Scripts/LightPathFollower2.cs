using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPathFollower2 : MonoBehaviour
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
	// Use this for initialization
	void Start()
	{
		delay = 0;
		//PathNode = GetComponentInChildren<>();
		CheckNode();
	}

	void CheckNode()
	{
		Timer = 0;
		startPosition = pointlight.transform.position;
		CurrentPositionHolder = PathNode[CurrentNode].transform.position;
		GetComponent<Light>().enabled = true;
	}

	// Update is called once per frame
	void Update()
	{

		Timer += Time.deltaTime * MoveSpeed;

		if (pointlight.transform.position != CurrentPositionHolder)
		{

			pointlight.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1*Timer);
			
		}
		else 
		{
			
			if (CurrentNode < PathNode.Length - 1)
			{
				
				CurrentNode++;
				CheckNode();
				if(CurrentNode==0)
				{
					GetComponent<Light>().enabled = false;
				}
			}
			if (CurrentNode== PathNode.Length -1)
			{
				delay += Time.deltaTime;
				if(delay>=max_time_to_reset)
				{
					
					CurrentNode = -1;
					delay=0;
				}
				

				
			}
			
			
			
		}
	}
}
