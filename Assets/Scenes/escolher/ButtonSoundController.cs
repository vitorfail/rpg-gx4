using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundController : MonoBehaviour
{
    public static ButtonSoundController Instance;

    public AudioClip clickSound;
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
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Chamada pública para tocar som
    public void PlayClickSound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}