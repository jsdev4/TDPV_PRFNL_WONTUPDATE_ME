using UnityEngine;

public class Ed102AnimController : MonoBehaviour
{
    private bool key_was_pressed;
    private Animator anim;
    public GameObject screen_object;
    public GameObject computer;
    public AudioSource[] sounds;
    void Start()
    {
        key_was_pressed = false;
        anim = GetComponent<Animator>();
    }

   
    void LateUpdate()
    {

        if (key_was_pressed == false)
        {
            anim.Play("Ed102pcing");
            computer.gameObject.GetComponent<Animator>().Play("VintageComputerCode");
        }
        if (key_was_pressed == true)
        {
            anim.Play("Ed102pcing_and_later_runnning");
            computer.gameObject.GetComponent<Animator>().Play("VintageComputerSSShutdown");
            sounds[0].Stop();
            if(computer.gameObject.GetComponent<TextEventsController>().Return_if_to_next_scene()==true)
			{
                computer.gameObject.GetComponentInChildren<Light>().enabled = false;
			}
        }
       
        if(screen_object.gameObject.GetComponent<TransitionSceneController>().Return_if_key_was_pressed()==true)
		{
            key_was_pressed = true;
		}
        
    }
   
}
