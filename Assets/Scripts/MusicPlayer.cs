using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        PlayerPrefsController.MasterVolume = 0.5f;
        SetVolume(PlayerPrefsController.MasterVolume);
    }

    // Update is called once per frame
    public void SetVolume(float volume) => audioSource.volume = volume;
}
