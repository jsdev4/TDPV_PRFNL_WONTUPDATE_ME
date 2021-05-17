using UnityEngine;

public class ScriptForPlayingSound01 : MonoBehaviour
{
    private AudioSource audio_s;
    public GameObject manager;
    public bool is_a_not_playing_audio_at_start;
    void Start()
    {
        audio_s = GetComponent<AudioSource>();
        if (is_a_not_playing_audio_at_start == false)
        {
            audio_s.Play();
        }
    }
    void LateUpdate()
    {
        if(manager.gameObject.GetComponent<ManagerScript>().Return_if_paused()==false)
		{
            audio_s.enabled = true;
		}
        else
		{
            audio_s.enabled = false;
		}
    }
}
