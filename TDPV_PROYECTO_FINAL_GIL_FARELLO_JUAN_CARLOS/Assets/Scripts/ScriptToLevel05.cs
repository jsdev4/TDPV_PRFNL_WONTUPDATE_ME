using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptToLevel05 : MonoBehaviour
{
    private bool to_new_level;
    private float timer;
    public GameObject fader;
    void Start()
    {
        timer = 0;
        to_new_level = false;
    }

    
    void Update()
    {
        if (to_new_level == true)
        {
            fader.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                SceneManager.LoadScene("Level_05_The_Outlands");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            to_new_level = true;
        }
    }
}
