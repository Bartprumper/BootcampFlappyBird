using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdCollisions : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI score;
    public Camera mainCamera;
    public ObstacleSpawner obstacleSpawner;
    public GameObject gameOverUI;
    public ParticleSystem checkpointParticles;
    private float totalScore = 0f;
    private bool gameOver = false;
    private float finalScoreYPos;
    private int finalScoreOffset = 375;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetScore();
        finalScoreYPos = score.transform.position.y - finalScoreOffset;
    }

    // Update is called once per frame
    void Update()
    {
        totalScore += Time.deltaTime;
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

    void SetScore()
    {
        score.text = "SCORE: " + math.round(totalScore).ToString();
    }

    private void GameOver()
    {
        playerController.enabled = false;
        mainCamera.GetComponent<CameraController>().enabled = false;
        gameOver = true;
        gameOverUI.SetActive(true);
        score.fontSize = 72;
        score.transform.position = new Vector3(score.transform.position.x, finalScoreYPos, score.transform.position.z);
    }
}
