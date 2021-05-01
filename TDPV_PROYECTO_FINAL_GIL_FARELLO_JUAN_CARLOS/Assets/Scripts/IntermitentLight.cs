using UnityEngine;

public class IntermitentLight : MonoBehaviour
{
	private bool is_shinning;
	public float delay;
	private float time_elapsed;
	private Light lamp;
	public float increase_intensity;
	//public float max_intensity;*/
	void Start()
	{
		is_shinning = false;
		lamp = GetComponent<Light>();

	}

	void Update()
	{
		if(is_shinning==false)
		{
			time_elapsed += Time.deltaTime;
			if(time_elapsed<=delay)
			{
				lamp.intensity += increase_intensity * Time.deltaTime;
			}
			else
			{
				time_elapsed = 0;
				is_shinning = true;
			}
		}
		if(is_shinning==true)
		{
			time_elapsed += Time.deltaTime;
			if(time_elapsed<=delay)
			{
				lamp.intensity -= increase_intensity * Time.deltaTime;
			}
			else
			{
				time_elapsed = 0;
				is_shinning = false;
			}
		}

		
	}

	
}
