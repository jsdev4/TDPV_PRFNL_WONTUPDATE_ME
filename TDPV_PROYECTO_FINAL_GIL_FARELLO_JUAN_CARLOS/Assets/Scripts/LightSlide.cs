using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSlide : MonoBehaviour
{
    public GameObject light_to_slide;
    private Transform trnsfrm;
    private Transform this_object;
    void Start()
    {
        this_object = GetComponent<Transform>();
        trnsfrm = light_to_slide.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trnsfrm.position.x <this_object.localScale.x)
        {
            light_to_slide.GetComponent<Transform>().Translate(Vector3.right*1*Time.deltaTime);
        }
        if (trnsfrm.position.x >= this_object.localScale.x)
        {
            light_to_slide.GetComponent<Transform>().Translate(this_object.localScale.x*-1,0,0);

        }

    }
}
