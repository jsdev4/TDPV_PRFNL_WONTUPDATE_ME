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
    private int numberOfTaggedObjects;
    void Start()
    {
        numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("WaitingIconBall").Length;
        timer = 0;
        special_icon_collected = false;
        icons_collected = 0;
        Debug.Log(numberOfTaggedObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if(special_icon_collected==true)
		{//enemies are good
            timer += Time.deltaTime;
            //call to enemies status bad or good
            if (timer >= critical_time)
			{
                //enemies are good
                //enemies flashing;
			}
            if (timer >= max_time)
            {
                //enemies back to normal
                //enemies are bad
                Debug.Log("Special icon is out");
                timer = 0;
                special_icon_collected = false;
            }
		}
        if(icons_collected==numberOfTaggedObjects)
		{
            //victory condition
            Debug.Log("all the objects were collected");
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
