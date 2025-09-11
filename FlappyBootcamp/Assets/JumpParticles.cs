using UnityEngine;

public class JumpParticles : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, -1, 0);

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
