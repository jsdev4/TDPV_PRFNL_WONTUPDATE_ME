using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryTreeController : MonoBehaviour
{
    public int min_range;
    public int max_range;
    private int random_number;
    private int random_delay;
    private float timer;
    Material material;
    void Start()
    {
        random_number = 0;
        random_delay = 0;
        timer = 0;
        material = GetComponent<Renderer>().material;
        random_number = Random.Range(0, 8);
    }

 
    void Update()
    {
        if(random_number<8)
		{
           
            random_delay = Random.Range(min_range,max_range  );
            Debug.Log(random_delay);
            timer += Time.deltaTime;
            if(timer>=random_delay)
			{
                random_number = Random.Range(0, 8);
                random_delay = 0;
                timer = 0;
			}
        }
        if (random_number==0||random_number==4)
        {
            material.mainTextureOffset = new Vector2(0f,0);

        }
        if (random_number == 1||random_number==5)
        {
            material.mainTextureOffset = new Vector2(0.25f, 0);

        }
        if (random_number == 2||random_number==6)
        {
            material.mainTextureOffset = new Vector2(0.5f, 0);

        }
        if (random_number == 3||random_number==7)
        {
            material.mainTextureOffset = new Vector2(0.75f, 0);

        }

    }

}
