using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneMusic
    {
        public string sceneName;
        public AudioClip musicClip;
    }

    public SceneMusic[] sceneMusicList;
    public AudioMixerGroup mixerGroup;
    public string mixerParameterName = "MusicVolume";

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixerGroup;

        // Find the first scene in the build settings and play its music
        Scene firstScene = SceneManager.GetSceneByBuildIndex(0);
        foreach (SceneMusic sceneMusic in sceneMusicList)
        {
            if (sceneMusic.sceneName == firstScene.name)
            {
                audioSource.clip = sceneMusic.musicClip;
                audioSource.Play();
                break;
            }
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (SceneMusic sceneMusic in sceneMusicList)
        {
            if (sceneMusic.sceneName == scene.name)
            {
                audioSource.clip = sceneMusic.musicClip;
                audioSource.Play();
                break;
            }
        }
    }

    public void SetVolume(float volume)
    {
        mixerGroup.audioMixer.SetFloat(mixerParameterName, volume);
    }

    public void SetPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }
}
