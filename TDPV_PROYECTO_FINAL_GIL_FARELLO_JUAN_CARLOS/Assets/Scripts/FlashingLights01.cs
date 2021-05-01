
using UnityEngine;

public class FlashingLights01 : MonoBehaviour
{
    private Light lamp;
    private bool increase_intensity;
    public float intensity;
    //public float intensity;
    private float timer;
    public float max_time_shine;
    void Start()
    {
        lamp = GetComponent<Light>();
        increase_intensity =true;
    }

    void Update()
    {
        if(increase_intensity==true)
		{
            timer += Time.deltaTime;
            lamp.intensity += intensity * Time.deltaTime;
            if(timer>=max_time_shine)
			{
                increase_intensity = false;
                timer = 0;
			}
		}
		else
		{
            timer += Time.deltaTime;
            lamp.intensity -= intensity * Time.deltaTime;
            if(timer>=max_time_shine)
			{
                increase_intensity = true;
                timer = 0;
			}
		}
    }
}
