using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private MeshRenderer battery_mesh;
    public Material[] materials;
    public GameObject player;
    void Start()
    {
        battery_mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if(player.gameObject.GetComponent<CharController>().Return_number_of_cells()==5)
        {
            battery_mesh.material = materials[0];
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() ==4)
        {
            battery_mesh.material = materials[1];
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() == 3)
        {
            battery_mesh.material = materials[2];
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() == 2)
        {
            battery_mesh.material = materials[3];
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() ==1)
        {
            battery_mesh.material = materials[4];
        }
        if (player.gameObject.GetComponent<CharController>().Return_number_of_cells() == 0)
        {
            battery_mesh.material = materials[5];
        }
    }
}
