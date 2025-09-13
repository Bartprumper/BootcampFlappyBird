using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject speedText;
    public UIDocument gameUI;
    public ParticleSystem jumpParticles;
    public float speed;
    public float jumpForce;
    public float forwardMomentum;
    private float movementX;
    private int speedIncreaseCounter = 1;
    private int speedIncreaseInterval = 5;
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
        if (speedIncreaseCounter == speedIncreaseInterval)
        {
            forwardMomentum += 1f;
            speedIncreaseCounter = 1;
            gameUI.GetComponent<GameUI>().ShowSpeedText();
        }
        else
        {
            speedIncreaseCounter++;
        }
    }


}
