using UnityEngine;
using UnityEngine.UI;
public class BuildingEntrance : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public GameObject fader;
    private bool player_here;
    public Text text;
    private AudioSource interacting_sound;
    void Start()
    {
        player_here = false;
        interacting_sound = GetComponent<AudioSource>();
    }

 
    void FixedUpdate()
    {
        //poner el fader antes de cambiar a otro escenario modificar el objecto publico player por fader
        if(player_here == true)
		{
            if (Input.GetKeyUp(KeyCode.F))
            {
                interacting_sound.Play();
                fader.SetActive(true);
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                ManagerKeeper.Is_ed102_entering_some_place(true);
              
            }
            if(fader.gameObject.GetComponent<FaderScript>().Return_animation_complete()==true)
			{
                player.gameObject.GetComponent<Transform>().position = respawnPoint.gameObject.GetComponent<Transform>().position;
                player_here = false;
                ManagerKeeper.Is_ed102_entering_some_place(false);
                fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
                fader.gameObject.GetComponent<FaderScript>().Set_animation_complete(false);
               
            }
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            player_here = true;
            if (text != null)
            {
                text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(true);
            }
		}
	}
    private void OnTriggerExit(Collider other)
	{
        if(other.CompareTag("Player"))
		{
            player_here = false;
            if (text != null)
            {
                text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(false);
            }
        }
	}
}
