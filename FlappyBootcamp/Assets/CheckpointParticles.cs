using UnityEngine;

public class CheckpointParticles : MonoBehaviour
{
    public Transform player;
    void LateUpdate()
    {
        transform.position = player.position;
    }
}
