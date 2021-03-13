using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractiveTextController02 : MonoBehaviour
{
    private bool display_text;
    private Text text;
   // public GameObject[] objects_for_text_display;
    void Start()
    {
        display_text = false;
        text = GetComponent < Text>();
        text.CrossFadeAlpha(0f, 0.05f, false);
    }

    
    void Update()
    {
        if(display_text==true)
		{
            text.CrossFadeAlpha(1f, 0.075f, false);
        }
        else
		{
            text.CrossFadeAlpha(0f, 0.5f, false);
        }
    }
    public void Set_if_display(bool dsply)
	{
        display_text = dsply;
	}
}
