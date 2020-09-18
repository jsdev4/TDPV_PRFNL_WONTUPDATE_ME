using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public bool direction;
    public float speed;
    public float acceleration;
    public bool on_trigger;
    private int random_direction;
    private Transform trnsfrm;
    public GameObject sprite_train;
    void Start()
    {
       
        trnsfrm = GetComponent<Transform>();
      //  trnsfrm1 = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        Vector3 left = new Vector3(-1, 1, 1);
        Vector3 right=new Vector3(1,1,1);
        if(on_trigger==false)
		{
            trnsfrm.Translate(Vector3.left * speed * Time.deltaTime);
            sprite_train.gameObject.GetComponent<Transform>().localScale = left;
		}
		else
		{
            trnsfrm.Translate(Vector3.right * speed * Time.deltaTime);
            sprite_train.gameObject.GetComponent<Transform>().localScale = right;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("TrainLimit"))
		{
            Debug.Log("touched");
            on_trigger = !on_trigger;
		}
    }
}
