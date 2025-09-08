using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float forwardMomentum;
    private float movementX;
    private int speedIncreaseInterval = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        rb.AddForce(movement * speed);
        transform.position += transform.forward * forwardMomentum * Time.deltaTime;
    }

    void OnMove(InputValue movementValue)
    {
        if (!this.enabled) return;
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnJump()
    {
        if (!this.enabled) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void IncreaseSpeed()
    {
        if (speedIncreaseInterval == 5)
        {
            forwardMomentum += 2f;
            speedIncreaseInterval = 0;
        }
        else
        {
            speedIncreaseInterval++;
        }
        
    }
}
