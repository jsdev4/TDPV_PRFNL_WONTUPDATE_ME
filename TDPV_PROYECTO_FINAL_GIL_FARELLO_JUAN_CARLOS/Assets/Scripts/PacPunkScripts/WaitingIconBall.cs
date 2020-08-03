using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingIconBall : MonoBehaviour
{
    public GameObject manager;
    private Transform trnsfrm;
    public float rotation_speed;
    private bool collected;
    void Start()
    {
        trnsfrm = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        for (int i = 0; i < 1; i++)
        {
            Vector3 icon_rotation = new Vector3(0, rotation_speed * Time.deltaTime, 0);
            trnsfrm.Rotate(icon_rotation, 30f, Space.Self);
            i = 0;
        }
       
        if(collected==true)
		{
            manager.gameObject.GetComponent<PacPunkManager>().Increase_icons_collected();
            Destroy(gameObject);
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            collected = true;
		}
	}
}
