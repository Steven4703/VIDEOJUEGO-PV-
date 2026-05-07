using UnityEngine;

public class CrashSound : MonoBehaviour
{
    public AudioClip crashClip;
    private AudioSource audioSource;

    // --- TU PARTE: El hueco para poner las chispas ---
    public GameObject efectoChispas;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.2f;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Esto es lo que ya tenían tus compañeros (El Sonido)
        if (crashClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(crashClip);
        }

        // --- TU PARTE: Crear las chispas en el punto del choque ---
        if (efectoChispas != null)
        {
            // collision.contacts[0].point es el lugar exacto donde se tocaron las naves
            Instantiate(efectoChispas, collision.contacts[0].point + Vector3.back * 0.5f, Quaternion.identity);
        }
    }
}