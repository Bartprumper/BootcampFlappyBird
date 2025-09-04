using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float forwardMomentum;
    private float movementX;
    //private float movementY;
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
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        //movementY = movementVector.y;
    }

    void OnJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
