using System.Collections;
using UnityEngine;

public class StopLightsController : MonoBehaviour
{
    private float delay;
    private float sincro_delay;
    public float max_sincro_delay;
    private bool ascendent;
    private int j;
    private ArrayList light_list;
    private string colorHex00;
    private string colorHex01;
    private string colorHex02;
    public GameObject trigger_to_stop_car;
    void Start()
    {
        delay = 0;
        j = 0;
        sincro_delay = 0;
        ascendent = true;
        colorHex00 = "#FF0000";
        colorHex01 = "#FFC600";
        colorHex02 = "#00FF31";
        light_list = new ArrayList { colorHex00, colorHex01, colorHex02 };
    } 
    void Update()
    {
        sincro_delay += Time.deltaTime;
        if (sincro_delay>=max_sincro_delay)
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
                    if (trigger_to_stop_car != null)
                    {
                        // trigger_to_stop_car.SetActive(false);
                        //  trigger_to_stop_car.gameObject.GetComponent<BoxCollider>().enabled = false;
                        /*    for (int i = 0; i < 7; i++)
                            {
                                car[i].gameObject.GetComponent<CarController>().Set_touched(false);
                            }*/
                        trigger_to_stop_car.gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                    StartCoroutine("ChangeLight");
                    j++;
                    delay = 0;

                }
                if (delay >= 3.5f && j == 2)
                {
                    //Debug.Log(j);
                    delay = 0;
                    ascendent = false;
                }

            }
            if (ascendent == false)
            {
                delay += Time.deltaTime;
                if (j == 2)
                {
                    StartCoroutine("ChangeLight");
                    // Debug.Log("j " + j);
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
                    if (trigger_to_stop_car != null)
                    {
                        //trigger_to_stop_car.SetActive(true);
                        // trigger_to_stop_car.gameObject.GetComponent<BoxCollider>().enabled = true;
                        trigger_to_stop_car.gameObject.GetComponent<BoxCollider>().enabled = true;
                    }
                    delay = 0;
                    ascendent = true;
                    sincro_delay = 0;
                }
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
