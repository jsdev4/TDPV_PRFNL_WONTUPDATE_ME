using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool direction;
    public float speed;
    private Transform _transform;
    public GameObject player;
    private bool player_on_it;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
 
        if(direction==true)
        {
            _transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
       else
        {
            _transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       if(player_on_it==true)
        {
            player.gameObject.GetComponent<Transform>().position = transform.position;
            player.gameObject.GetComponent<Transform>().Translate(Vector3.down * 1);
            if(Input.GetKeyUp(KeyCode.F))
            {
                player_on_it = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("HookCollider"))
        {
            direction = !direction;
        }
        if(collision.collider.CompareTag("Player"))
        {
            player_on_it = true;
        }
    }
}
