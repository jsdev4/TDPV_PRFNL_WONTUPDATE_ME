using UnityEngine;

public class ScriptForPlayingSound : MonoBehaviour
{
    private bool first_step;
    private bool second_step;
    public AudioSource[] steps;

    public void Set_first_step()
    {
        steps[0].Play();
    }
    public void Set_second_step()
    {
        steps[1].Play();
    }
}
