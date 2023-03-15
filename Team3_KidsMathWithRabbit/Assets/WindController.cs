using UnityEngine;

public class WindController : MonoBehaviour
{
    public float windStrength = 5f;
    public float windChangeInterval = 5f;

    private Vector3 windDirection;

    private void Start()
    {
        InvokeRepeating("ChangeWindDirection", 0f, windChangeInterval);
    }

    private void FixedUpdate()
    {
        Rigidbody[] leafRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody leafRigidbody in leafRigidbodies)
        {
            if (leafRigidbody.gameObject.CompareTag("Leaf"))
            {
                leafRigidbody.AddForce(windDirection * windStrength, ForceMode.Force);
            }
        }
    }

    private void ChangeWindDirection()
    {
        windDirection = Random.onUnitSphere;
    }
}
