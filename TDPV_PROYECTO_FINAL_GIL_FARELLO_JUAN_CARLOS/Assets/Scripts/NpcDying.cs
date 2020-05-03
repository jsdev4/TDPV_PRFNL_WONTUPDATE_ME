using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDying : MonoBehaviour
{
    private Transform trnsfrm;
    private Vector3 rotation_sprite;
    private bool is_flipped;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (trnsfrm.rotation.z > 0)
        {
            rotation_sprite = new Vector3(-1, 1, 1);
            trnsfrm.localScale = rotation_sprite;
            is_flipped = true;
         //forward -20
        }
        if (trnsfrm.rotation.z < 0)
        {
            rotation_sprite = new Vector3(1, 1, 1);
            trnsfrm.localScale = rotation_sprite;
            is_flipped = false;
          //back -20
        }
    }
    public void hit_the_ground()
    {
        if (is_flipped == true)
        {
            GetComponentInChildren<Transform>().transform.Rotate(Vector3.forward, -20);
        }
       if(is_flipped==false)
        {
            GetComponentInChildren<Transform>().transform.Rotate(Vector3.back, -20);
        }
    }
}
