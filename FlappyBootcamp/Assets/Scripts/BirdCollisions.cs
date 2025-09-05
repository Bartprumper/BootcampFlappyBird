using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdCollisions : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI score;
    public Camera mainCamera;
    private float survivalTime = 0f;
    private bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        survivalTime += Time.deltaTime;
        if (!gameOver)
        {
            SetScore(); 
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            survivalTime += 10;
            SetScore();
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerController.enabled = false;
            mainCamera.GetComponent<CameraController>().enabled = false;
            gameOver = true;
        }
    }

    void SetScore()
    {
        score.text = "SCORE: " + math.round(survivalTime).ToString();
    }
}
