using UnityEngine;

public class TrainController : MonoBehaviour
{
    public bool direction;
    private float current_speed;
    public float speed;
    public float acceleration;
    public bool on_trigger;
    private int random_direction;
    private Transform trnsfrm;
    public GameObject sprite_train;
    void Start()
    {
        current_speed = 0;
        trnsfrm = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        Vector3 left = new Vector3(-1, 1, 1);
        Vector3 right=new Vector3(1,1,1);
        current_speed+= acceleration * Time.deltaTime;
        if(on_trigger==false)
		{
            if (current_speed <= speed)
            {
              //  Debug.Log("left speed is "+current_speed);
                trnsfrm.Translate(Vector3.left * current_speed * Time.deltaTime);
                sprite_train.gameObject.GetComponent<Transform>().localScale = left;
            }
			else
			{
                trnsfrm.Translate(Vector3.left * speed * Time.deltaTime);
                sprite_train.gameObject.GetComponent<Transform>().localScale = left;
            }
		}
		else
		{
            if (current_speed <= speed)
            {
                //Debug.Log("right speed is "+current_speed);
                trnsfrm.Translate(Vector3.right * current_speed * Time.deltaTime);
                sprite_train.gameObject.GetComponent<Transform>().localScale = right;
            }
            else
            {
                trnsfrm.Translate(Vector3.right * speed * Time.deltaTime);
                sprite_train.gameObject.GetComponent<Transform>().localScale = right;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("TrainLimit"))
		{
         //   Debug.Log("speed setted to "+current_speed);
            on_trigger = !on_trigger;
            current_speed = 0;
		}
    }
}
