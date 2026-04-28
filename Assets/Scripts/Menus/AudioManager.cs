using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    private AudioSource audioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        if (musicClip != null)
        {
            PlayMusic(false, musicClip);
        }
        musicSlider.onValueChanged.AddListener(delegate { SetVolume(musicSlider.value); });
    }


    public void SetVolume(float volume)
    {
        audioSource.volume=volume;
    }


    public void PauseMusic() 
    {
        audioSource.Pause();

    }

    public void PlayMusic(bool loopSong, AudioClip audioClip=null)
    {
        if (musicClip != null)
        {
            audioSource.clip=musicClip;
        }
        if (audioSource.clip != null)
        {
            if (loopSong)
            {
                audioSource.Stop();
            }
            audioSource.Play();
        }
    }
}
