using UnityEngine;

public class AudioLetras : MonoBehaviour
{
    private AudioSource musicSource;
    public AudioClip audioClip;
    public bool play = false;
    public bool onplay = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(play && !onplay){
            onplay =true;
            musicSource.Play(); // Pausa a música
        }
        if(musicSource.isPlaying){
            play = false;
        }
    }

}
