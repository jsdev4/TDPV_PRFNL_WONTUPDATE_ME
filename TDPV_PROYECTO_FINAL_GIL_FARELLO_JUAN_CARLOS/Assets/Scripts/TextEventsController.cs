using UnityEngine;

public class TextEventsController : MonoBehaviour
{
    private bool start_timer;
    private bool to_next_level;
    void Start()
    {
        start_timer = false;
        to_next_level = false;
    }
   /* void Update()
    {
        
    }*/
    public void Text_is_centered()
    {
        start_timer = true;

    }
    public void Text_is_out()
    {
        to_next_level = true;
    }
    public bool Return_if_start_timer()
	{
        return start_timer;
	}
    public bool Return_if_to_next_scene()
	{
        return to_next_level;
	}
    public void Set_text_out_false()
	{
        to_next_level = false;
	}
}
