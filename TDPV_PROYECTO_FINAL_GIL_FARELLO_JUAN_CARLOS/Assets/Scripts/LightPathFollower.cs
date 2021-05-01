using UnityEngine;

public class LightPathFollower : MonoBehaviour
{

	public GameObject[] PathNode;
	public GameObject pointlight;
	public float MoveSpeed;
	float Timer;
	static Vector3 CurrentPositionHolder;
	int CurrentNode;
	private Vector3 startPosition;
	private float delay;

	void Start()
	{
		//CurrentNode = 0;

	}

	void CheckNode()
	{
		Timer = 0;
		startPosition =transform.position;
		CurrentPositionHolder = PathNode[CurrentNode].gameObject.GetComponent<Transform>().position;

		pointlight.gameObject.GetComponent<Light>().enabled=true;

	}
	void Update()
	{

			Timer += Time.deltaTime * MoveSpeed;

			if (pointlight.gameObject.GetComponent<Transform>().position != CurrentPositionHolder)
			{

				pointlight.gameObject.GetComponent<Transform>().position = Vector3.Lerp(startPosition, CurrentPositionHolder, 1 * Timer);
			}
			else
			{
				if (CurrentNode < PathNode.Length-1)
				{

					CurrentNode++;
					CheckNode();
					if (CurrentNode == 0)
					{
						pointlight.gameObject.GetComponent<Light>().enabled = false;
					}
				}
				if (CurrentNode == PathNode.Length-1)
				{
					delay += Time.deltaTime;
					if (delay >= 2)
					{

						CurrentNode = -1;
						delay = 0;
					}
				}
			}

	}
}
