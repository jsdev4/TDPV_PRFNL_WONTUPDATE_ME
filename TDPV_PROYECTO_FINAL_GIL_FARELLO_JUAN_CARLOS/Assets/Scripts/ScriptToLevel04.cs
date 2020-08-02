using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptToLevel04 : MonoBehaviour
{
    private bool to_new_level;
    void Start()
    {
        to_new_level = false;
    }
    void Update()
    {
        if(to_new_level==true)
		{
            SceneManager.LoadScene("Level_04_Stereo_City");
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            to_new_level = true;
		}
	}
}
