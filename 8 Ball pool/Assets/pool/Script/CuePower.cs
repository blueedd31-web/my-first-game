using UnityEngine;
using UnityEngine.UI;

public class CuePower : MonoBehaviour
{
    public Transform cueStick;
    public float maxForce = 1200f;
    public float chargeSpeed = 800f;

    public Image powerFill;

    private Rigidbody rb;
    private float power;
    private bool charging;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (powerFill != null)
            powerFill.fillAmount = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            charging = true;
            power = 0f;
        }

        if (Input.GetMouseButton(0) && charging)
        {
            power += chargeSpeed * Time.deltaTime;
            power = Mathf.Clamp(power, 0, maxForce);

            if (powerFill != null)
                powerFill.fillAmount = power / maxForce;
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

        rb.AddForce(dir * power);

        power = 0f;

        if (powerFill != null)
            powerFill.fillAmount = 0f;
    }
}