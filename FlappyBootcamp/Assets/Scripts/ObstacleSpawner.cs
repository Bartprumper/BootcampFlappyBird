using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public List<GameObject> obstacles;
    public Transform playerTransform;
    private float obstacleSpawnZ = 20f; // Waar de obstakels beginnen te spawnen
    private int obstacleCount = 3; // Hoeveel obstakels er tegelijk actief zijn
    private float obstacleSpacing = 20f; // Hoe ver de obstakels uit elkaar staan
    void Start()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefabs[i], obstaclePrefabs[i].transform.position, obstaclePrefabs[i].transform.rotation, transform);
            obstacles.Add(obstacle);
            obstacle.SetActive(false);
        }
        for (int i = 0; i < obstacleCount; i++)
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
        obstacles[index].transform.position = new Vector3(obstacles[index].transform.position.x, obstacles[index].transform.position.y, obstacleSpawnZ);
        obstacles[index].SetActive(true);
        obstacles.RemoveAt(index);
        obstacleSpawnZ += obstacleSpacing;
    }

    void DespawnObstacle(GameObject obstacle)
    {
        obstacle.transform.parent.gameObject.SetActive(false);
        obstacles.Add(obstacle.transform.parent.gameObject);
    }

    public void Cycle(GameObject obstacle)
    {
        SpawnObstacle();
        DespawnObstacle(obstacle);
    }

}
