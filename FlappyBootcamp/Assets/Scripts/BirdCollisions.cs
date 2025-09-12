using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BirdCollisions : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI score;
    public Camera mainCamera;
    public ObstacleSpawner obstacleSpawner;
    public GameObject gameOverUI;
    public ParticleSystem checkpointParticles;
    public UIDocument gameUI;
    private float totalScore = 0f;
    private bool gameOver = false;
    void Update()
    {
        totalScore += Time.deltaTime;
        if (!gameOver)
        {
            gameUI.GetComponent<GameUI>().UpdateScore(totalScore);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            totalScore += 10;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            obstacleSpawner.Cycle(other.gameObject);
            checkpointParticles.Play();
            playerController.IncreaseSpeed();
        }
    }



    private void GameOver()
    {
        playerController.enabled = false;
        mainCamera.GetComponent<CameraController>().enabled = false;
        gameOver = true;
        gameOverUI.transform.gameObject.SetActive(true);
        gameUI.GetComponent<GameUI>().FinalScore(totalScore);
    }
}
