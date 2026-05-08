using UnityEngine;

public class SonidoPorCiclo : MonoBehaviour
{
    private ParticleSystem ps;
    private AudioSource audioS;
    private bool yaSono = false;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Si las partículas están naciendo y aún no suena en este ciclo
        if (ps.time > 0 && !yaSono)
        {
            audioS.Play();
            yaSono = true;
        }
        // Cuando el ciclo termina (vuelve a 0), reseteamos para la próxima
        if (ps.time == 0)
        {
            yaSono = false;
        }
    }
}