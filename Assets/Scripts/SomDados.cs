using UnityEngine;

public class SomDados : MonoBehaviour
{
    public static SomDados Instance;

    public AudioClip[] sonsRolando;       // Vários sons de rolagem
    public AudioClip somFinalizando;      // Som do dado parando
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton para acesso global
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Toca um som aleatório de rolagem
    public void PlaySomRolando()
    {
        if (sonsRolando != null && sonsRolando.Length > 0)
        {
            int index = Random.Range(0, sonsRolando.Length);
            audioSource.Stop();
            audioSource.PlayOneShot(sonsRolando[index]);
        }
    }

    // Toca o som finalizando
    public void PlaySomFinalizando()
    {
        if (somFinalizando != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(somFinalizando);
        }
    }
}
