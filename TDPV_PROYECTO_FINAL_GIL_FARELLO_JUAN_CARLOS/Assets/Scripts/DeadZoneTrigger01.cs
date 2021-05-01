using UnityEngine;

public class DeadZoneTrigger01 : MonoBehaviour
{
    private bool player_is_here;
    private bool others_npc_fallen;
    public GameObject npc;
    GameObject clone;
    void Start()
    {

    }
    void Update()
    {
        if (player_is_here == true && others_npc_fallen == false)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 position = new Vector3(Random.Range(210.0f, 230.0f), (Random.Range(-65f,-72f)), (Random.Range(-1.5f, 1.5f)));
                clone=Instantiate(npc, position, Quaternion.identity);

            }
            others_npc_fallen = true;
        }
        if(player_is_here==false&&others_npc_fallen==true)
        {
            others_npc_fallen = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player_is_here = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player_is_here = false;
        }
    }
   
}