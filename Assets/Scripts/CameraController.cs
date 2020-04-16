using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.2f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothSpeed);
        transform.LookAt(player);
    }
}
