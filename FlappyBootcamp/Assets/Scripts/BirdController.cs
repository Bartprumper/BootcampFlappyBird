using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public ParticleSystem jumpParticles;
    public float speed;
    public float jumpForce;
    public float forwardMomentum;
    private float movementX;
    private int speedIncreaseInterval = 0;
    private int rotationSpeed = 150;
    private int rotationY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        rb.AddForce(movement * speed);
        transform.position += Vector3.forward * forwardMomentum * Time.deltaTime;
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationY * rotationSpeed * Time.deltaTime);
    }

    void OnMove(InputValue movementValue)
    {
        if (!this.enabled) return;
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        rotationY = (int)movementVector.x;
    }

    void OnJump()
    {
        if (!this.enabled) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpParticles.Play();
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
