using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    private bool emitting;
    private ParticleSystem particles;
	void Awake()
	{
		particles = GetComponent<ParticleSystem>();
		particles.Stop();
	}



    void Update()
    {
        if(emitting==true)
		{
            particles.Play();
		}
        else
		{
            particles.Pause();
		}
    }
	private void OnBecameVisible()
	{
        emitting = true;
	}
	private void OnBecameInvisible()
	{
        emitting = false;
	}
}
