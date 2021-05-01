using UnityEngine;
using UnityEngine.UI;
public class InteractiveTextDisplayForLevelPlaces01 : MonoBehaviour
{
    public Text text;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//on_trigger = true;
			text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//on_trigger = false;
			text.gameObject.GetComponent<InteractiveTextController02>().Set_if_display(false);
		}
	}
}
