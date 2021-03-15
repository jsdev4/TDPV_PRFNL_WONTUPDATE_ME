using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractiveTextControllerForLevelPlaces : MonoBehaviour
{
    private float timer;
    private bool on_trigger;
    public Text very_interactive_text;
    private BoxCollider bxclldr;
    void Start()
    {
        timer = 0;
        on_trigger = false;
        very_interactive_text.CrossFadeAlpha(0f, .05f, false);
        bxclldr = GetComponent<BoxCollider>();
    }

    void Update()
    {

            if (on_trigger == true)
            {
                timer += Time.deltaTime;
                if (timer < 5f)
                {
                very_interactive_text.CrossFadeAlpha(1f, .075f, false);
                }
                if (timer > 5f)
                {
                    very_interactive_text.CrossFadeAlpha(0f, .5f, false);
                    timer = 0;
                    on_trigger = false;
                    bxclldr.enabled = false;
                }
            }

    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        { on_trigger = true;
        }
	}
	
}
