using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotorController : MonoBehaviour
{
    public float rotation_angle;
    private Transform trnsfrm;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
    }
    void Update()
    {
        trnsfrm.Rotate(0, rotation_angle * Time.deltaTime, 0);
    }
}
