using UnityEngine;

public class ObjectDisplacementController : MonoBehaviour
{
    private bool max_displacement;
    private float mov_speed;
    public float initial_speed;
    public float acceleration;
    public float clearance_to_rebound;
    private Vector3 first_pos;
    private Transform trnsfrm;
    private float acceleration_aux;
    public GameObject Object_for_max_displacement;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
        first_pos = trnsfrm.position;
        max_displacement = false;
        acceleration_aux = acceleration;
    }
    void Update()
    {
        if(max_displacement==false)
		{
            if(trnsfrm.position.y>Object_for_max_displacement.gameObject.GetComponent<Transform>().position.y+clearance_to_rebound)
			{

                float aux = initial_speed;
                aux+= acceleration * Time.deltaTime;
                mov_speed = aux;
                trnsfrm.Translate(Vector3.down * mov_speed);
            }
			if(trnsfrm.position.y < Object_for_max_displacement.gameObject.GetComponent<Transform>().position.y+ clearance_to_rebound)
			{

                float aux = mov_speed;
                    aux-= acceleration * Time.deltaTime;
                    mov_speed = aux;
                trnsfrm.Translate(Vector3.down * mov_speed);
            }
		}
        else
		{
            if(trnsfrm.position.y<first_pos.y)
			{
                trnsfrm.Translate(Vector3.up* mov_speed/2);
            }
            if (trnsfrm.position.y >= first_pos.y)
            {
                max_displacement = false;
            }
        }
    }
	public void OnCollisionEnter(Collision collision)
	{
        if (collision.collider.CompareTag("TriggerForDisplacement"))
        {
            max_displacement = true;
        }
	}
}
