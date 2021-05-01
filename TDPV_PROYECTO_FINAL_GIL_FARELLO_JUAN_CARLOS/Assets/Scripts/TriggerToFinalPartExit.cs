
using UnityEngine;

public class TriggerToFinalPartExit : MonoBehaviour
{
    public GameObject fader;
    private bool player_here;
    void Start()
    {
        
    }
    void Update()
    {
        if(player_here==true)
		{
            fader.gameObject.GetComponent<FaderScript>().Set_the_fade_out();
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            player_here = true;
		}
	}
}
