using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagingDataPc : MonoBehaviour
{
    private float time_elapsed;
    public float delay;
    private int random_for_mesh_display;
    private MeshRenderer pc_mesh;
    public Material[] pc_material;

    void Start()
    {
        random_for_mesh_display = 0;
        pc_mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        time_elapsed += Time.deltaTime;
        if(time_elapsed>=delay)
		{
            Generate_random();
            time_elapsed = 0;
		}
        if(random_for_mesh_display==0)
		{
            pc_mesh.material = pc_material[0];
		}
        if(random_for_mesh_display==1)
		{
            pc_mesh.material = pc_material[1];
		}
        if (random_for_mesh_display == 2)
        {
            pc_mesh.material = pc_material[2];
        }
        if (random_for_mesh_display == 3)
        {
            pc_mesh.material = pc_material[3];
        }
    }
    private void Generate_random()
	{
        random_for_mesh_display = Random.Range(0, 3);
	}
}
