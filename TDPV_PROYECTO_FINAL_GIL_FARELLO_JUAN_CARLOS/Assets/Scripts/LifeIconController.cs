using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifeIconController : MonoBehaviour
{
    private MeshRenderer life_mesh;
    public Material[] life_icon_material;
    public GameObject player;
    private RectTransform rect_transform;
    void Start()
    {
        life_mesh = GetComponent<MeshRenderer>();
        rect_transform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if(player.gameObject.GetComponent<CharController>().Return_number_of_lifes()==3)
        {
            life_mesh.material = life_icon_material[0];
            rect_transform.localScale = new Vector3(90, 30, 0);
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_lifes() == 2)
        {
            life_mesh.material = life_icon_material[1];
            rect_transform.localScale = new Vector3(60, 30, 0);
            rect_transform.localPosition = new Vector3(-815, 350, 0);
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_lifes() == 1)
        {
            life_mesh.material = life_icon_material[2];
            rect_transform.localScale = new Vector3(30, 30, 0);
            rect_transform.localPosition = new Vector3(-830, 350, 0);
        }
        if(player.gameObject.GetComponent<CharController>().Return_number_of_lifes()==0)
        {
            life_mesh.enabled = false;
        }
       
    }
}
