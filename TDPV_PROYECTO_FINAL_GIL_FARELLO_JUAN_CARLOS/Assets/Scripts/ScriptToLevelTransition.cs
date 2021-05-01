using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptToLevelTransition : MonoBehaviour
{
    private bool to_new_level;
    private bool reached_level;
    private float timer;
    public GameObject fader;
    void Start()
    {
        to_new_level = false;
        timer = 0;
        reached_level = false;
    }
    void Update()
    {
        if (to_new_level == true)
        {
            if (reached_level == false)
            {
                ManagerKeeper.Increase_number_of_level();
                reached_level = true;
            }
            for (int i = 0; i < 1; i++)
            {
                fader.SetActive(true);
            }
            if (fader == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    SceneManager.LoadScene("TransitionScene");//poner aca la escena de transicion con el mensaje de complete level
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
