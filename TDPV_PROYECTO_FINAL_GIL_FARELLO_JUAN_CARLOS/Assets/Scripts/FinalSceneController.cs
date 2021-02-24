using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinalSceneController : MonoBehaviour
{
    private bool Ed_finished_running;
    private bool Ed_stopped_the_idle;
    private bool key_pressed;
    private bool Ed102_has_saluted;
    private bool start_timer;
    private float timer;
    private Animator anim;
    private Transform trnsfrm;
    public GameObject cam;

    public GameObject fader;
    public GameObject outland_guy;
    public GameObject first_text;
    public GameObject first_text_outland_guy;
    public GameObject second_text;
    public GameObject second_text_outland_guy;
	 void Awake()
	{
        fader.SetActive(true);
        fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
        timer = 0;
        start_timer = false;
    }
	void Start()
    {
        Ed_finished_running = false;
        Ed_stopped_the_idle = false;
        key_pressed = false;
        Ed102_has_saluted = false;
        anim = GetComponent<Animator>();
        trnsfrm = GetComponent<Transform>();
        anim.Play("Ed102_running_final_scene");
        outland_guy.gameObject.GetComponent<Animator>().Play("OutlandGuyIdle");
       /* first_text_outland_guy.gameObject.GetComponent<Animator>().enabled = false;
        second_text.gameObject.GetComponent<Animator>().enabled = false;*/
    }
    void Update()
    {
        if(trnsfrm.position.x<=30f)
		{
            first_text.gameObject.GetComponent<Animator>().enabled = true;
            first_text.gameObject.GetComponent<Animator>().Play("finalScene_firstText");  
		}
     
        if (trnsfrm.position.x>=37f)
		{
            cam.transform.parent = null;
		}
        if (Ed_finished_running == true)
        {
            anim.Play("Ed102_idle_looking_back");
        }
        if(Ed_stopped_the_idle==true)
		{
            Ed_finished_running = false;
            anim.Play("Ed102_idle_on_final_scene");
            first_text_outland_guy.SetActive(true);
            if (first_text_outland_guy.gameObject.GetComponent<TextEventsController>().Return_if_start_timer()==true)
			{
                StartCoroutine("Fade_the_first_text");
            }
            if (first_text_outland_guy.gameObject.GetComponent<TextEventsController>().Return_if_to_next_scene() == true)
            {
                second_text.SetActive(true);
            }
            if (second_text.gameObject.GetComponent<TextEventsController>().Return_if_start_timer() == true)
            {
                StartCoroutine("Fade_the_second_text");
            }
            if(second_text.gameObject.GetComponent<TextEventsController>().Return_if_to_next_scene()==true)
			{
                second_text_outland_guy.SetActive(true);
			}
            if(second_text_outland_guy.gameObject.GetComponent<TextEventsController>().Return_if_start_timer()==true)
			{
                if(Input.GetKeyUp(KeyCode.Return))
				{
                    StartCoroutine("Fade_the_second_outland_guy_text");
                    key_pressed = true;
                    Ed_stopped_the_idle = false;
                }
			}
           


        }
        if(key_pressed==true&&Ed_stopped_the_idle==false)
		{
            anim.Play("Ed102_saying_hi");
            outland_guy.gameObject.GetComponent<Animator>().Play("OutlandGuyInteracting");
		}
        if(Ed102_has_saluted==true)
		{
            key_pressed = false;
            anim.Play("Ed102_disappearing");
            outland_guy.gameObject.GetComponent<Animator>().Play("OutlandGuyIdle");
        }
        if(trnsfrm.position.x>=49f)
		{
            fader.SetActive(true);
            StartCoroutine("To_the_main_menu");
		}
    }
    public void Stop_finish()
    {
        Ed_finished_running = true;
    }
    public void Stop_idle()
    {
        Ed_stopped_the_idle = true;    
    }
    public void Said_hi()
	{
        Ed102_has_saluted = true;
	}

    IEnumerator Fade_the_first_text()
	{
        yield return new WaitForSeconds(2);
        first_text_outland_guy.gameObject.GetComponent<Animator>().Play("firstTextOutlandGuyOut");
	}
    IEnumerator Fade_the_second_text()
    {
        yield return new WaitForSeconds(2);
       // first_text_outland_guy.SetActive(false);
       second_text.gameObject.GetComponent<Animator>().Play("finalScene_secondTextOut");
    }
    IEnumerator Fade_the_second_outland_guy_text()
	{
        yield return new WaitForSeconds(2);
        second_text_outland_guy.gameObject.GetComponent<Animator>().Play("secondTextOutlandGuyOut");
	}
    IEnumerator To_the_main_menu()
	{
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main_Menu");
	}
}
