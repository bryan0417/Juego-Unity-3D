using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio)
    {
        if (audioSource != null && audio != null)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}
