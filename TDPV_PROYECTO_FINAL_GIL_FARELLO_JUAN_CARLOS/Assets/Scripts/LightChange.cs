using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    private ArrayList colors;
    private string colorHex01;
    private string colorHex02;
    private string colorHex03;
    private string colorHex04;
    private int j;
    private float delay;
    void Start()
    {
        j =0;
        colorHex01 = "#EBFFFE";
        colorHex02 = "#1BCF00";
        colorHex03 = "#00CF3D";
        colorHex04 = "#27D495";
        colors = new ArrayList { colorHex01, colorHex02, colorHex03, colorHex04, colorHex01 };
        
    }
    IEnumerator ChangeLights()
    {
        yield return new WaitForSeconds(.3f);
        Color newCol;

     
            if (ColorUtility.TryParseHtmlString(colors[j].ToString(), out newCol))
            {
                gameObject.GetComponentInChildren<Light>().color = newCol;
               
            }
       
        
    }
    // Update is called once per frame
    void Update()
    {

        delay += Time.deltaTime;
        if(delay>=.3f)
        {
            StartCoroutine("ChangeLights");
            delay= 0;
            j++;
        }
        if(j==4)
        {
            j = 0;
        }
        
    }
}
