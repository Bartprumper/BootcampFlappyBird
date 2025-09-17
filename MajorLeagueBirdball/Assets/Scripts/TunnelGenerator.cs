using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour
{
    public GameObject tunnelPrefab;
    public Transform playerTransform;
    private Queue<GameObject> tunnels = new Queue<GameObject>();
    private int tunnelsInQueue = 3;
    //private int activeTunnels = 3;
    private int tunnelLength = 100;
    private int spawnZ = 0;

    void Start()
    {
        for (int i = 0; i < tunnelsInQueue; i++)
        {
            GameObject tunnel = Instantiate(tunnelPrefab, transform.position, transform.rotation, transform);
            tunnel.SetActive(false);
            tunnels.Enqueue(tunnel);
        }
        for (int i = 0; i < tunnels.Count; i++)
        {
            SpawnTunnel();
        }
    }

    void SpawnTunnel()
    {
        GameObject tunnel = tunnels.Dequeue();
        tunnel.transform.position = new Vector3(tunnel.transform.position.x, tunnel.transform.position.y, spawnZ);
        tunnel.SetActive(true);
        tunnels.Enqueue(tunnel);
        spawnZ += tunnelLength;
    }

    void DespawnTunnel(GameObject tunnel)
    {
        tunnel.SetActive(false);
    }

    public void Cycle()
    {
        GameObject lastTunnel = tunnels.Peek();
        if (playerTransform.position.z > lastTunnel.transform.position.z + tunnelLength)
        {
            DespawnTunnel(lastTunnel);
            SpawnTunnel();
        }
    }

}
