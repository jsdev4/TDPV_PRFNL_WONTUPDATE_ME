
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
	public float delay;
	private float time_elapsed;
	private Light lamp;
	public float min_intensity;
	public float max_intensity;
	void Start()
	{
		lamp= GetComponent<Light>();

	}

	void Update()
	{
		if (lamp != null)
		{
			time_elapsed += Time.deltaTime;
			if (time_elapsed >= delay)
			{
				time_elapsed = 0;
				Make_light_flash();
			}

		}
	}
	private void Make_light_flash()
	{
		if (lamp != null)
		{
			if (lamp.intensity == min_intensity)
			{
				lamp.intensity = max_intensity;
			
			}
			else if (lamp.intensity == max_intensity)
			{
				lamp.intensity = min_intensity;

			}
		}
	}
}
