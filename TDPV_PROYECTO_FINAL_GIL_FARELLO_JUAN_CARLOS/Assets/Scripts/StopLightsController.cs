using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLightsController : MonoBehaviour
{
    private float delay;
    private bool ascendent;
    private int j;
    private ArrayList light_list;
    private string colorHex00;
    private string colorHex01;
    private string colorHex02;
  //  private Light light_bulb;
    void Start()
    {
        delay = 0;
        j = 0;
        ascendent = true;
        colorHex00 = "#FF0000";
        colorHex01 = "#FFC600";
        colorHex02 = "#00FF31";
    //    light_bulb = GetComponentInChildren<Light>();
        light_list = new ArrayList { colorHex00, colorHex01, colorHex02 };
    }

    
    void Update()
    {
        
        if (ascendent == true)
        {
            delay += Time.deltaTime;
            if (delay >= 5f && j == 0)
            {
                StartCoroutine("ChangeLight");
                j++;
                delay = 0;
            }
            if (delay >= 1.5f && j == 1)
            {
                StartCoroutine("ChangeLight");
                j++;
                delay = 0;

            }
            if (delay >= 3.5f && j == 2)
            {
                Debug.Log(j);
                delay = 0;
                ascendent = false;
            }
            
        }
        if(ascendent==false)
		{
            delay += Time.deltaTime;
            if(j==2)
			{
                StartCoroutine("ChangeLight");
                Debug.Log("j is here" + j);
                j--;
                delay = 0;
            }
            if (delay >= 1.5f && j == 1)
            {

                StartCoroutine("ChangeLight");
                j--;
                delay = 0;
            }
            if (j == 0)
            {
                delay = 0;
                ascendent = true;
            }
        }
		
    }
    IEnumerator ChangeLight()
	{
        yield return new WaitForSeconds(0);
        Color newCol;
        if (ColorUtility.TryParseHtmlString(light_list[j].ToString(), out newCol))
        {
            gameObject.GetComponentInChildren<Light>().color = newCol;

        }
    }
}
