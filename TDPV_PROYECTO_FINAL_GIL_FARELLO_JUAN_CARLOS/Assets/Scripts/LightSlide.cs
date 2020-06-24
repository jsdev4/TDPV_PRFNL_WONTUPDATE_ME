using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSlide : MonoBehaviour
{
    public GameObject light_to_slide;
    private Transform trnsfrm;
    public float speed_of_light;
    private Vector3 first_pos;
    void Start()
    {
       
       trnsfrm = light_to_slide.gameObject.GetComponent<Transform>();
        first_pos = trnsfrm.position;
    }
    void Update()
    {
        if (light_to_slide.gameObject.GetComponent<Transform>().localPosition.x<0.5f)
        {
            light_to_slide.gameObject.GetComponent<Transform>().Translate(Vector3.right*speed_of_light*Time.deltaTime);
        }
        if (light_to_slide.gameObject.GetComponent<Transform>().localPosition.x >= 0.5f)
        {
            light_to_slide.gameObject.GetComponent<Transform>().position = first_pos;
        }
    }
}
