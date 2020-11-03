using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookWithTheBox02 : MonoBehaviour
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
    public int CurrentNode;
void Start()
{

}
void Update()
{
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
