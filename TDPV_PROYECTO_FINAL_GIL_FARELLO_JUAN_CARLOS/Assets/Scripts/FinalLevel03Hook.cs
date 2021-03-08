using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel03Hook : MonoBehaviour
{
    public GameObject first_object;
    public GameObject last_object;
    public GameObject player;
    public GameObject wall_to_remove;
    private Transform trnsfrm;
    private Rigidbody rb;
    public float speed;
    private float timer;
    private Vector3 start_position;
    private bool on_board;
    void Start()
    {
       
        timer = 0;
        on_board = false;
        trnsfrm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        start_position = first_object.gameObject.GetComponent<Transform>().position;
        trnsfrm.position = start_position;
    }


    void FixedUpdate()
    {

        if(on_board==true)
		{
            Vector3 currentPos = transform.position;
            Vector3 currentPosFixed = new Vector3(currentPos.x, currentPos.y - 2f, currentPos.z);
            timer += Time.fixedDeltaTime;
           // trnsfrm.transform.position = Vector3.SmoothDamp(trnsfrm.position, last_object.gameObject.GetComponent<Transform>().position, ref speed, 0.8f);
              rb.MovePosition(Vector3.Lerp(start_position, last_object.gameObject.GetComponent<Transform>().position, speed * timer));
           // trnsfrm.transform.position = Vector3.Lerp(start_position, last_object.gameObject.GetComponent<Transform>().position, speed * timer);
            player.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;
            player.gameObject.GetComponent<CharController>().Set_if_is_on_the_hook(true);
            player.gameObject.GetComponent<Rigidbody>().MovePosition(currentPosFixed);
            wall_to_remove.gameObject.SetActive(false);
           
		}
    }
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
            on_board = true;
		}
	}
}
