using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookStandardMovement2Colliders : MonoBehaviour
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
            trnsfrm.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            trnsfrm.Translate(Vector3.left * speed * Time.deltaTime);
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
