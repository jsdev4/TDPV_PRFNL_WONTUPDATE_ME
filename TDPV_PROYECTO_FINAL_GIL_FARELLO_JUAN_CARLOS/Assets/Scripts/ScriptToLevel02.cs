using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptToLevel02 : MonoBehaviour
{
    private bool to_new_level;
    void Start()
    {
        to_new_level = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(to_new_level==true)
        {
            SceneManager.LoadScene("Level_02_Factory");
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
