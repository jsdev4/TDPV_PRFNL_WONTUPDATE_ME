using UnityEngine;

public class CameraFollowerScript : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.0125f;
    public Vector3 offset;
    public Vector3 offset_left;

    void LateUpdate()
    {
        if (target.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == true)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

        }
        if (target.gameObject.GetComponent<CharController>().Return_if_is_fffffflipped() == false)
        {
            Vector3 desiredPosition = target.position + offset_left;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
