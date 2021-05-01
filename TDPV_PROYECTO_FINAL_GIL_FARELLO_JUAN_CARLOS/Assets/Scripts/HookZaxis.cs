using UnityEngine;

public class HookZaxis : MonoBehaviour
{
    public bool direction;
    public float speed;
    private Transform trnsfrm;
    public GameObject player;
    private AudioSource hook_sound;
    public GameObject manager;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
        hook_sound = GetComponent<AudioSource>();
        hook_sound.Play();
    }
    void Update()
    {
        if (manager.gameObject.GetComponent<ManagerScript>().Return_if_paused() == false)
        {
            hook_sound.enabled = true;
            Vector3 currentPos = trnsfrm.position;
            if (direction == true)
            {
                trnsfrm.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                trnsfrm.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        else
		{
            hook_sound.enabled = false;
		}

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HookCollider"))
        {
            direction = !direction;
        }
    
    }
}
