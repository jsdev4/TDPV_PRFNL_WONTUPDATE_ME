using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptToLevelTransition01 : MonoBehaviour
{
    private bool to_new_level;
    private bool reached_level;
    private float timer;
    public GameObject fader;
    public GameObject level_complete_text;
    private bool start_timer;
    void Start()
    {
        to_new_level = false;
        reached_level = false;
        start_timer = false;
    }
    void Update()
    {
        if (to_new_level == true)
        {
            if (reached_level == false)
            {
                ManagerKeeper.Increase_number_of_level();
               // Debug.Log("number of level reached is " + ManagerKeeper.Get_number_of_reached_level());
                reached_level = true;
            }
            if (reached_level == true)
            { 
                level_complete_text.SetActive(true);
                if (level_complete_text.gameObject.GetComponent<LevelCompleteTextController>().Return_if_centered() == true)
                {
                    start_timer = true;
                }
                if (start_timer == true)
                {
                    timer += Time.deltaTime;
                    if (timer > 5f)
                    {
                       // Debug.Log("timer is over 5");
                        level_complete_text.gameObject.GetComponent<Animator>().Play("LevelCompleteTextOut");
                        if (level_complete_text.gameObject.GetComponent<LevelCompleteTextController>().Return_if_out() == true && ManagerKeeper.Get_number_of_reached_level() == 2)
                        {
                            fader.SetActive(true);
                            if (fader == true)
                            {
                                if (timer >= 9.5f)
                                {
                                    SceneManager.LoadScene("Level_03_Lab");//poner aca la escena de transicion con el mensaje de complete level
                                }
							}
                        }
                    }
                }
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
