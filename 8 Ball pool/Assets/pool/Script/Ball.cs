using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isPocketed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pocket"))
        {
            isPocketed = true;
            gameObject.SetActive(false);
        }
    }
}