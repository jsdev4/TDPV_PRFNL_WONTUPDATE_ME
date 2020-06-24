using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioCellController : MonoBehaviour
{
    public float speed_ray;
    private bool can_pick;
    private bool is_up;
    private float firstPosY;

    public GameObject player;
    Transform trnsfrm;
    public GameObject ray;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
        firstPosY = trnsfrm.position.y;
        can_pick = false;
        is_up = false;

    }


    void Update()
    {
        Vector3 rotation = new Vector3(0, 1 * Time.deltaTime, 0);
        ray.gameObject.GetComponent<Transform>().transform.Rotate(rotation,1f,Space.Self);
        if (is_up ==false)
        {
           
            trnsfrm.transform.Translate(Vector3.up * speed_ray * Time.deltaTime);
            if (trnsfrm.transform.position.y>= firstPosY+0.25f)
            {
                is_up = true;
            }
        }
        if(is_up==true)
        {
            trnsfrm.transform.Translate(Vector3.down * speed_ray * Time.deltaTime);
            if(trnsfrm.transform.position.y<= firstPosY)
            {
                is_up = false;
            }
        }
        
        if(can_pick==true)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() < 5)
                {
                    player.gameObject.GetComponent<CharController>().Increase_number_of_cells();
                    Destroy(gameObject);//call obejct on gui to display an full cells message
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            can_pick = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            can_pick = false;
        }
    }
}
