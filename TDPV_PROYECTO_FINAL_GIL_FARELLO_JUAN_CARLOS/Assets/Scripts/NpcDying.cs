using UnityEngine;

public class NpcDying : MonoBehaviour
{

    public GameObject the_quad;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("deadZone"))
        {
            GetComponentInChildren<Animator>().enabled = true;
            GetComponentInChildren<Animator>().Play("NpcDying");
        }
    }
}
