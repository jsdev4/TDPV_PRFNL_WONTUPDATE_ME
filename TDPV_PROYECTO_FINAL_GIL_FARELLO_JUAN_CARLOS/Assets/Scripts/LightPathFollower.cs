using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPathFollower : MonoBehaviour
{

	public GameObject[] PathNode;
	public GameObject Player;
	public float MoveSpeed;
	float Timer;
	static Vector3 CurrentPositionHolder;
	int CurrentNode;
	private Vector3 startPosition;
	private float delay;

	void Start()
	{
		delay = 0;
		CheckNode();
	}

	void CheckNode()
	{
		Timer = 0;
		startPosition = Player.transform.position;
		CurrentPositionHolder = PathNode[CurrentNode].transform.position;
		GetComponent<Light>().enabled = true;
	}
	void Update()
	{ 
		Timer += Time.deltaTime * MoveSpeed;

		if (Player.transform.position != CurrentPositionHolder)
		{

			Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1*Timer);
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
				if(delay>=2)
				{
					
					CurrentNode = -1;
					delay=0;
				}
			}	
		}
	}
}
