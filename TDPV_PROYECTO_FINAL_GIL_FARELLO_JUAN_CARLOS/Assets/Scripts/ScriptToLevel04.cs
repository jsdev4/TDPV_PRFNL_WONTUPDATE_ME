using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptToLevel04 : MonoBehaviour
{
    private bool to_new_level;
    private bool run_fader;
    private float timer;
    public GameObject fader;
    void Start()
    {
        timer = 0;
        to_new_level = false;
        run_fader = false;
    }
    void Update()
    {
        if(to_new_level==true&&run_fader==false)
		{
            for (int i = 0; i < 1; i++)
            {
                fader.SetActive(true);
                run_fader = true;
                
            }
		}
        if(to_new_level==true&&run_fader==true)
		{
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                SceneManager.LoadScene("Level_04_Stereo_City");
            }
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
