using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameManager : MonoBehaviour
{

    public GameObject keeper;
    void Start()
    {
        
    }
    void Update()
    {
        //key to return to exit this scene
        if(Input.GetKeyUp(KeyCode.Escape))
		{
            
            SceneManager.LoadSceneAsync("Level_03_Lab");
         
        }
    }
}
