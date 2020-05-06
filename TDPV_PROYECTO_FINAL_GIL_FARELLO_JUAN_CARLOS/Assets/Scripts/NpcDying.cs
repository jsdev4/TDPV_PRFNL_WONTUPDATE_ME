using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDying : MonoBehaviour
{

    public GameObject the_quad;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("deadZone"))
        {
            GetComponentInChildren<Animator>().enabled = true;
            GetComponentInChildren<Animator>().Play("NpcDying");
        }
    }
}
