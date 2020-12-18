using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookZaxis : MonoBehaviour
{
    public bool direction;
    public float speed;
    private Transform trnsfrm;
    public GameObject player;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 currentPos = trnsfrm.position;
        if (direction == true)
        {
            trnsfrm.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            trnsfrm.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HookCollider"))
        {
            direction = !direction;
        }
    
    }
}
