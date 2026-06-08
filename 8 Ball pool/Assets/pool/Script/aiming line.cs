using UnityEngine;

public class AimLineSimple : MonoBehaviour
{
    public Transform cueStick;
    public Transform cueBall;
    public LineRenderer line;

    public float lineLength = 5f;
    public float heightOffset = 0.05f;

    void Update()
    {
        if (cueStick == null || cueBall == null || line == null) return;

        // Direction from cue stick to ball
        Vector3 dir = (cueBall.position - cueStick.position).normalized;

        // Lift line slightly above table
        Vector3 start = cueBall.position + Vector3.up * heightOffset;
        Vector3 end = start + dir * lineLength;

        line.SetPosition(0, start);
        line.SetPosition(1, end);
    }
}