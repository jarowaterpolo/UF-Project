using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAudio : MonoBehaviour
{
    //public List<List<AudioSource>> SceneListAudioSource = new List<List<AudioSource>>();
    public List<AudioSource> audioSources;
    public List<AudioSource> audioSourcesStart;
    public List<AudioSource> audioSourcesUpdate;
    public enum PlayType {Start, Update}
    public PlayType currentPlayType = PlayType.Start;

    private int SceneNumber;

    private void Start()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;

        if (currentPlayType == PlayType.Start)
        {
            int i = 0;
            foreach (var source in audioSources) 
            {
                i++;
                audioSources[i-1].Play();
            }
        }
    }

    public void Update()
    {
        if (currentPlayType == PlayType.Update)
        {
            int i = 0;
            foreach (var source in audioSources)
            {
                i++;
                audioSources[i].Play();
            }
        }
    }
}
