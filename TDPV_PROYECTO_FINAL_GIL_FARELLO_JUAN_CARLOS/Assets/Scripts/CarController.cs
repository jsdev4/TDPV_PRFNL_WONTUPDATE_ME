using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] PathNode;
	public  GameObject car;
	public GameObject trigger_for_detection;
    private Vector3 CurrentPositionHolder;
    public int CurrentNode;
    private Vector3 startPosition;
	public float max_speed;
    public float acceleration;
	private float current_speed;
	private bool touched;
	public GameObject trigger;
	public bool is_car_to_right;
    void Start()
    {
		touched = false;
    }

	void CheckNode()
	{
		current_speed = 0;
		startPosition = car.gameObject.GetComponent<Transform>().position;
		CurrentPositionHolder = PathNode[CurrentNode].gameObject.GetComponent<Transform>().position;
	}
	void Update()
	{
		if (touched == true)
		{
			//Debug.Log("speed is o");
			if(trigger.gameObject.GetComponent<BoxCollider>().enabled==false)
			{
				touched = false;
			}
		}
		if (touched == false)
		{
			trigger_for_detection.SetActive(false);
			current_speed += acceleration * Time.deltaTime;
			if (current_speed > max_speed)
			{
				current_speed = max_speed;
			}
			if (car.gameObject.GetComponent<Transform>().position != CurrentPositionHolder)
			{
				
				car.gameObject.GetComponent<Transform>().position = Vector3.Lerp(car.gameObject.GetComponent<Transform>().position, CurrentPositionHolder, 1 * current_speed);
			}
			else
			{
				if (CurrentNode < PathNode.Length-1)
				{		
					CurrentNode++;
					CheckNode();
				}
				if (CurrentNode == PathNode.Length-1 )
				{ 
					CurrentNode = -1;
				}
			}
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("TriggerToStopCar")&&is_car_to_right==false)
		{
			touched = true;
			current_speed = 0;
			trigger_for_detection.SetActive(true);
		}
		if (other.CompareTag("TriggerForCarDetection") && is_car_to_right == false)
		{
			touched = true;
			current_speed = 0;
		}
		if (other.CompareTag("TriggerToStopCarRight") && is_car_to_right == true)
		{
			touched = true;
			current_speed = 0;
			trigger_for_detection.SetActive(true);
		}
		if (other.CompareTag("TriggerForCarDetection") && is_car_to_right == true)
		{
			touched = true;
			current_speed = 0;
		}
	}
	public void Set_touched(bool tchd)
	{
		touched = tchd;
	}
}

