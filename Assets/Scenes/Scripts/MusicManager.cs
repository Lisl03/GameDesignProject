using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance; // Singleton-Instanz
    private AudioSource audioSource;

    public AudioClip normalMusic;
    public AudioClip nightmareMusic;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Verhindert doppelte MusicManager
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Behalte Musik über Szenenwechsel hinweg

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Falls kein AudioSource vorhanden ist
        }

        audioSource.loop = true;
        PlayNormalMusic();
    }

    public void PlayNormalMusic()
    {
        if (audioSource.clip != normalMusic)
        {
            audioSource.Stop();
            audioSource.clip = normalMusic;
            audioSource.Play();
        }
    }

    public void PlayNightmareMusic()
    {
        if (audioSource.clip != nightmareMusic)
        {
            audioSource.Stop();
            audioSource.clip = nightmareMusic;
            audioSource.Play();
        }
    }
}
 