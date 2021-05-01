using UnityEngine;
public class ElevatorButtonSpecial01 : MonoBehaviour
{
    private bool can_use;
    private bool going_move;
    public float max_time;
    private float delay_for_elevator;
    public GameObject player;
    public GameObject elevator;
    public GameObject text;
    private AudioSource button_sound;
    void Start()
    {
        can_use = false;
        going_move = false;
        button_sound = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (can_use == true )
        {
           
            if (Input.GetKeyDown(KeyCode.F))
            {
                button_sound.Play();
                player.gameObject.GetComponent<CharController>().Set_if_is_interacting(true);
                going_move = true;
            }
            if(going_move==true)
            {
                delay_for_elevator += Time.deltaTime;
                if (delay_for_elevator >= max_time)
                {
                    elevator.gameObject.GetComponent<ElevatorSpecial>().Set_if_is_up(true);
                    elevator.gameObject.GetComponent<ElevatorSpecial>().Set_level(2);
                    delay_for_elevator = 0;
                    going_move = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can_use = true;
            text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can_use = false;
            text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(false);
        }
    }
}
