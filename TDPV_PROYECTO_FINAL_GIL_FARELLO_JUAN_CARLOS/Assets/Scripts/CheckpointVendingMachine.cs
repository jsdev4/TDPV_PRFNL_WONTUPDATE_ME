using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckpointVendingMachine : MonoBehaviour
{
    public int checkpoint_number;
    private bool checkpoint_passed;
    private bool checkpoint_enabled;
    public GameObject player;
    public GameObject trigger_to_save;
    public GameObject soda_object;
    public Text[] very_interactive_text;

    private float delay;
    void Start()
    {
        checkpoint_passed = false;
        checkpoint_enabled = false;
        very_interactive_text[0].CrossFadeAlpha(0.0f, 0.05f, false);
        very_interactive_text[1].CrossFadeAlpha(0.0f, 0.05f, false);
    }

    void Update()
    {
        if (checkpoint_passed == true && checkpoint_enabled == false)
        {
            very_interactive_text[0].CrossFadeAlpha(1.0f, .075f, false);
            if (Input.GetKeyUp(KeyCode.F))
            {
                Vector3 targetDir = new Vector3(transform.position.x - 2, transform.position.y + 2, transform.position.z - 1.5f) - transform.position;
                checkpoint_number += 1;
                player.gameObject.GetComponent<CharController>().Set_respawn_point(checkpoint_number);
                trigger_to_save.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
                soda_object.gameObject.SetActive(true);
                soda_object.gameObject.GetComponent<Rigidbody>().AddForce(targetDir * 1.5f, ForceMode.Impulse);
                Debug.Log("checkppoint :" + checkpoint_number);
                checkpoint_passed = false;
                checkpoint_enabled = true;
            }
        }
        if (checkpoint_passed == false && checkpoint_enabled == true)
        {
            very_interactive_text[0].CrossFadeAlpha(0f, .5f, false);
            very_interactive_text[1].CrossFadeAlpha(0f, .5f, false);
        }
        if (checkpoint_passed == false && checkpoint_enabled == false)
        {
            very_interactive_text[0].CrossFadeAlpha(0f, .5f, false);
        }
        if (checkpoint_passed == true && checkpoint_enabled == true)
        {
            very_interactive_text[1].CrossFadeAlpha(1.0f, .075f, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpoint_passed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpoint_passed = false;
        }
    }
}
