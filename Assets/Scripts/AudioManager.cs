using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource BackgroundSoundsForest;
    public bool BackgroundAudioPlaying = false;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Prevent duplicates
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);  // Keep it across scenes
    }

    private void Start()
    {
        //GameObject ForestAudio = GameObject.FindGameObjectWithTag("ForestAudio");
        //BackgroundSoundsForest = ForestAudio.AddComponent<AudioSource>();

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayBackgroundAudio();
        }
        else
        {
            BackgroundSoundsForest.Stop();
        }
    }

    void PlayBackgroundAudio()
    {
        if (BackgroundAudioPlaying == false) 
        {
            BackgroundSoundsForest.Play();
            BackgroundAudioPlaying = true;
        }
    }
}
