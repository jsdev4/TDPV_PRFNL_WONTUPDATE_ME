using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractiveTextController : MonoBehaviour
{
    private Text text;
    private float timer;
    private bool fade_the_text;
    void Start()
    {
        text = GetComponent<Text>();
        timer = 0;
        fade_the_text = false;
    }

    
    void Update()
    {
        if (timer < 3f)
        {
            timer += Time.deltaTime;
        }
        if(timer>3f)
		{
            timer = 0;
            fade_the_text = true;
		}
        if(fade_the_text==true)
		{
            text.CrossFadeAlpha(0f, .5f, false);
		}
    }
}
