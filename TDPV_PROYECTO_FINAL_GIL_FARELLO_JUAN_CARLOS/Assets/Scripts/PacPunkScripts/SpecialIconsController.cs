using UnityEngine;

public class SpecialIconsController : MonoBehaviour
{
    private bool collected;
    private bool is_up;
    private float firstPosY;
    public float speed;
    public GameObject manager;
    private Transform trnsfrm;
    //public GameObject player;
    public AudioSource collected_sound;
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
        firstPosY = trnsfrm.position.y;
        is_up = false;
        collected = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_up == false)
        {

            trnsfrm.transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (trnsfrm.transform.position.y >= firstPosY + 0.25f)
            {
                is_up = true;
            }
        }
        if (is_up == true)
        {
            trnsfrm.transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (trnsfrm.transform.position.y <= firstPosY)
            {
                is_up = false;
            }
        }
        if (collected==true)
		{
            manager.gameObject.GetComponent<PacPunkManager>().Increase_special_icon_collected();
            Destroy(gameObject);
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            collected = true;
            collected_sound.Play(); 
		}
	}
}
