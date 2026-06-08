using UnityEngine;

public class CueHit : MonoBehaviour
{
    public Transform cueStick;
    public float maxForce = 1200f;
    public float chargeSpeed = 800f;

    private Rigidbody rb;
    private float currentForce = 0f;
    private bool charging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            charging = true;
            currentForce = 0f;
        }

        if (Input.GetMouseButton(0) && charging)
        {
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0, maxForce);
        }

        if (Input.GetMouseButtonUp(0) && charging)
        {
            Shoot();
            charging = false;
        }
    }

    void Shoot()
    {
        if (cueStick == null) return;

        Vector3 dir = (transform.position - cueStick.position).normalized;

        rb.AddForce(dir * currentForce);

        currentForce = 0f;
    }
}