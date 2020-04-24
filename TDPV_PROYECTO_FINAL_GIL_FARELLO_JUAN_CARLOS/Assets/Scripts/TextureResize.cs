﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TextureResize : MonoBehaviour
{
	private float scaleFactor=3.5f;
	Material mat;
	void Start()
	{
		Debug.Log("Start");
		GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor);
	}
	void Update()
	{
		if (transform.hasChanged && Application.isEditor && !Application.isPlaying)
		{
			Debug.Log("The transform has changed!");
			GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor);
			transform.hasChanged = false;
		}
	}
}
