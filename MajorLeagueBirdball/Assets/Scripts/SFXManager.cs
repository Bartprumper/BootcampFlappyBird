using Unity.Mathematics;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    [SerializeField] private AudioSource SFXObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip clip, Transform transformOrigin, float volume, float pitch)
    {
        AudioSource audioSource = Instantiate(SFXObject, transformOrigin.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
