using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Transform trnsfrm;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private float firstPosX;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
        firstPosX = trnsfrm.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = new Vector3(firstPosX, 12, player.position.z);
        transform.position = Vector3.SmoothDamp(new Vector3(firstPosX, trnsfrm.position.y, player.position.z), target, ref velocity, smoothTime);
    /*    if (player.gameObject.GetComponent<CharControllerForPacPunk>().Set_moving_up() == true)
        {
            // Vector3 target = player.TransformPoint(new Vector3(0, 12, -1));
            transform.position = Vector3.SmoothDamp(new Vector3(firstPosX, trnsfrm.position.y, trnsfrm.position.z), target, ref velocity, smoothTime);

        }
        if (player.gameObject.GetComponent<CharControllerForPacPunk>().Set_moving_up() == false)
        {
            //Vector3 target = player.TransformPoint(new Vector3(0,12,10));
            transform.position = Vector3.SmoothDamp(new Vector3(firstPosX, trnsfrm.position.y, trnsfrm.position.z), target, ref velocity, 0);


        }*/
    }
}