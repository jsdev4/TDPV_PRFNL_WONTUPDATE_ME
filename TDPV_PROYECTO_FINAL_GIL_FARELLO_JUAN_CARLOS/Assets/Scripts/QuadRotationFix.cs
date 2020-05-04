using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadRotationFix : MonoBehaviour
{
    private Transform trnsfrm;
    private Transform self_transform;
    private bool on_dead_zone;
    private float delay;
    void Start()
    {
        trnsfrm = GetComponentInParent<Transform>();
        self_transform = GetComponent<Transform>();
        on_dead_zone = false;
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
     
            if (trnsfrm.rotation.z > 0)
            {
                self_transform.RotateAround(trnsfrm.position, Vector3.back, 100*Time.deltaTime);
                on_dead_zone = true;
              
            }
            if(trnsfrm.rotation.z<0)
            {
                self_transform.RotateAround(trnsfrm.position, Vector3.forward, 100 * Time.deltaTime);
               // on_dead_zone = true;
           
            }
            if(on_dead_zone==true)
        {
            self_transform.Translate(Vector3.up * 1 * Time.deltaTime);
            on_dead_zone = false;
        }
       
    }
}
