using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public List<GameObject> obstacles;
    public Transform playerTransform;
    private float obstacleSpacing = 20f;
    void Start()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefabs[i], obstaclePrefabs[i].transform.position, obstaclePrefabs[i].transform.rotation, transform);
            obstacles.Add(obstacle);
            obstacle.SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            SpawnObstacle();
        }
    }

    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstacles.Count);
        obstacles[index].transform.position = new Vector3(obstacles[index].transform.position.x, obstacles[index].transform.position.y, playerTransform.position.z + obstacleSpacing);
        obstacles[index].SetActive(true);
        obstacles.RemoveAt(index);
        obstacleSpacing += 20f;
    }

    void DespawnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstacles.Add(obstacle);
    }
}
