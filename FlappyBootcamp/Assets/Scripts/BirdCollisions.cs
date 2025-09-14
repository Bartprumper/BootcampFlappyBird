using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BirdCollisions : MonoBehaviour
{
    public PlayerController playerController;
    public Camera mainCamera;
    public TunnelGenerator tunnelGenerator;
    public ObstacleSpawner obstacleSpawner;
    public GameObject gameOverUI;
    public ParticleSystem checkpointParticles;
    public UIDocument gameUI;
    public AudioClip[] audioClips;
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
            SFXManager.instance.PlaySFXClip(audioClips[2], transform, 1f, UnityEngine.Random.Range(0.7f, 1.2f));
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
            tunnelGenerator.Cycle();
            SFXManager.instance.PlaySFXClip(audioClips[1], transform, 1f, UnityEngine.Random.Range(0.7f, 1.2f));
        }
    }



    private void GameOver()
    {
        if (gameOver) return;
        SFXManager.instance.PlaySFXClip(audioClips[0], transform, 1f, 1f);
        playerController.enabled = false;
        mainCamera.GetComponent<CameraController>().enabled = false;
        gameOverUI.transform.gameObject.SetActive(true);
        gameUI.GetComponent<GameUI>().FinalScore(totalScore);
        gameOver = true;
    }
}
