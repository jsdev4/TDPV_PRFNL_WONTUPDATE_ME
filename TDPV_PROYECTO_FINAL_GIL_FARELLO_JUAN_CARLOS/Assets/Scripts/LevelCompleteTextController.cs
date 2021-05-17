using UnityEngine;

public class LevelCompleteTextController : MonoBehaviour
{
    private bool text_is_centered;
    private bool text_is_out;
    void Start()
    {
        text_is_centered = false;
        text_is_out = false;
    }

    public void Text_is_centered()
	{
        text_is_centered = true;
	}
    public void Text_is_out()
	{
        text_is_out = true;
	}
    public bool Return_if_centered()
	{
        return text_is_centered;
	}
    public bool Return_if_out()
    {
        return text_is_out;
    }
}
