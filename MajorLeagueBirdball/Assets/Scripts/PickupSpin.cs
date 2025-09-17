using UnityEngine;

public class PickupSpin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
    }
}
