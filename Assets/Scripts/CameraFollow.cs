using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector2 deadZone = new Vector2(2f, 1.5f); // half-width and half-height of the box

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector2 offset = player.position - pos;

        if (offset.x > deadZone.x) pos.x += offset.x - deadZone.x;
        else if (offset.x < -deadZone.x) pos.x += offset.x + deadZone.x;

        if (offset.y > deadZone.y) pos.y += offset.y - deadZone.y;
        else if (offset.y < -deadZone.y) pos.y += offset.y + deadZone.y;

        transform.position = pos;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, deadZone * 2f);
    }
}