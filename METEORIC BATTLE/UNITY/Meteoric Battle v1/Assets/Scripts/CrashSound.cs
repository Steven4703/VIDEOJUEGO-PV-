using UnityEngine;

public class CrashSound : MonoBehaviour
{
    public AudioClip crashClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.2f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (crashClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(crashClip);
        }
    }
}