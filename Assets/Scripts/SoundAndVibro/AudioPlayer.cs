using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSystem _audioSystem;
    [SerializeField] private int _vibrateDuration;
    private Dictionary<SettingOption, bool> _settingOption = new Dictionary<SettingOption, bool>();


    private void Start()
    {
        InitSettingOption();

        SettingSwitch.OptionChanged += onOptionUpdated;

        foreach (Button b in Resources.FindObjectsOfTypeAll(typeof(Button)))
        {
            b.onClick.AddListener(onButtonClick);

        }
        BallUnifier.BallUnited += onBallUnited;
        UpdateLevelMusic();
    }

    private void InitSettingOption()
    {
        _settingOption.Add(SettingOption.Music, AppData.GetSettingValue(SettingOption.Music));
        _settingOption.Add(SettingOption.Sound, AppData.GetSettingValue(SettingOption.Sound));
        _settingOption.Add(SettingOption.Vibro, AppData.GetSettingValue(SettingOption.Vibro));
    }

    private void onOptionUpdated(SettingOption option)
    {
        UpdateOption(option);
        if (option == SettingOption.Music)
            UpdateLevelMusic();
    }
    private void onButtonClick()
    {
        PlaySound(SoundKey.ButtonClick);
        doVibro();
    }

    private void onBallUnited(Ball ball)
    {
        PlaySound(SoundKey.BallUnited);
        doVibro();
    }

    private void UpdateOption(SettingOption option)
    {
        _settingOption[option] = AppData.GetSettingValue(option);
    }

    private void PlaySound(SoundKey soundKey)
    {
        if (_settingOption[SettingOption.Sound])
            _audioSystem.Play(soundKey);
    }

    private void doVibro()
    {
        if (_settingOption[SettingOption.Vibro])
            Vibration.NativeVibration.Vibrate(_vibrateDuration);
    }

    private void UpdateLevelMusic()
    {
        if (_settingOption[SettingOption.Music] && _audioSystem.IsPlaying(SoundKey.LevelMusic) == false)
            _audioSystem.Play(SoundKey.LevelMusic);

        if (_settingOption[SettingOption.Music] == false)
            _audioSystem.Stop(SoundKey.LevelMusic);
    }

}
