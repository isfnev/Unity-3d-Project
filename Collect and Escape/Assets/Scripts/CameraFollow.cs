using UnityEngine;

public class CameraFollow2_5D : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private Vector3 targetPosition, smoothPosition;

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = smoothPosition;

        transform.LookAt(player);
    }
}

