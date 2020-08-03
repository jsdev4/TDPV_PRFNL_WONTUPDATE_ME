using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacPunkManager : MonoBehaviour
{
    private float timer;
    public float max_time;
    public float critical_time;
    private int icons_collected;
    private bool special_icon_collected;
    void Start()
    {
        timer = 0;
        special_icon_collected = false;
        icons_collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(special_icon_collected==true)
		{
            timer += Time.deltaTime;
            //call to enemies status bad or good
            if (timer >= critical_time)
			{

                //enemies flashing;
			}
            if(timer>=max_time)
			{
                //enemies back to normal
                //enemies are bad
                Debug.Log("Special icon is out");
                timer = 0;
                special_icon_collected = false;
			}

		}
    }
    public void Increase_icons_collected()
	{
        icons_collected += 1;
        Debug.Log(icons_collected);
	}
    public void Set_special_icon_collected()
	{
        Debug.Log("special icon is collected");
        special_icon_collected = true;
	}
}
