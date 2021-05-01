using UnityEngine;
using UnityEngine.UI;
public class InteractiveTextController02 : MonoBehaviour
{
    private bool display_text;
    private Text text;
    public GameObject manager;
    void Start()
    {
        display_text = false;
        text = GetComponent < Text>();
        text.CrossFadeAlpha(0f, 0.05f, false);
    }

    
    void LateUpdate()
    {
        if(display_text==true&& manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false)
		{
            text.enabled = true;
            text.CrossFadeAlpha(1f, 0.075f, false);
        }
        
        if(display_text == true && manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == true)
		{
            text.enabled = false;
            Debug.Log("hide me ");
        }
        if(display_text==false)
        {
            text.CrossFadeAlpha(0f, 0.5f, false);
        }
    }
    public void Set_if_display(bool dsply)
	{
        display_text = dsply;
	}
}
