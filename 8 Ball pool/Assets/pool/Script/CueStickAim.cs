using UnityEngine;

public class CueStickAim : MonoBehaviour
{
    public Transform cueBall;
    public float distance = 1.5f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(cueBall.position).z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = (cueBall.position - worldPos).normalized;

        transform.position = cueBall.position + dir * distance;

        transform.LookAt(cueBall.position);
    }
}