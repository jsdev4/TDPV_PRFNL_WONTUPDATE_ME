using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] PathNode;

	//private Transform trnsfrm;
	public  GameObject car;
    private Vector3 CurrentPositionHolder;
    public int CurrentNode;
    private Vector3 startPosition;
    public float delay;

    public float max_speed;
    public float acceleration;
    private float timer;
    float Timer;
	public int number;
    void Start()
    {
		//CurrentNode = 2;
    }

	void CheckNode()
	{
		Timer = 0;
		startPosition = car.gameObject.GetComponent<Transform>().position;
		CurrentPositionHolder = PathNode[CurrentNode].gameObject.GetComponent<Transform>().position;
	}
		void Update()
		{
			Timer += Time.deltaTime * max_speed;

			if (car.gameObject.GetComponent<Transform>().position != CurrentPositionHolder)
			{

				car.gameObject.GetComponent<Transform>().position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1 * Timer);
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
					//delay += Time.deltaTime;
					if (Timer >=delay)
					{

						CurrentNode = -1;
						Timer = 0;
					}
				}
			}
			
		}
}

