using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject cam;
    public float speed;

    void Update()
    {
        float interpolation = speed * Time.time;

        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, cam.transform.position.x, interpolation);
        position.y = Mathf.Lerp(this.transform.position.y, cam.transform.position.y, interpolation);
        this.transform.position = position;
    }
}
