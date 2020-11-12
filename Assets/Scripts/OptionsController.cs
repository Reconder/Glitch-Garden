using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    MusicPlayer musicPlayer;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 5;
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.MasterVolume;
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Update is called once per frame
    void Update() => ChangeVolumeOnSliderChange();

    private void ChangeVolumeOnSliderChange()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found.");
        }
    }

    public void SaveAndBackToMenuButton()
    {
        PlayerPrefsController.MasterVolume = volumeSlider.value;
        PlayerPrefsController.MasterDifficulty = difficultySlider.value;
        FindObjectOfType<LevelLoader>().LoadStartMenu();
    }

    public void DefaultsButton()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
