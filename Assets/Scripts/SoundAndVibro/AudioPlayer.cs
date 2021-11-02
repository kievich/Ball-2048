using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSystem _audioSystem;
    [SerializeField] private int _vibrateDuration;
    private Dictionary<SettingOption, bool> _settingOption = new Dictionary<SettingOption, bool>();
    [SerializeField] private PopUp _lastBallPopUp;

    private void Start()
    {
        InitSettingOption();

        SettingSwitch.OptionChanged += onOptionUpdated;

        foreach (Button button in Resources.FindObjectsOfTypeAll(typeof(Button)))
            button.onClick.AddListener(onButtonClick);

        BallUnifier.BallUnited += onBallUnited;
        Booster.Performed += onBoosterPerformed;
        _lastBallPopUp.Showed += onLastBallPopUpCreated;
        UpdateLevelMusic();
    }

    private void OnDestroy()
    {
        SettingSwitch.OptionChanged -= onOptionUpdated;

        foreach (Button button in Resources.FindObjectsOfTypeAll(typeof(Button)))
            button.onClick.RemoveListener(onButtonClick);

        BallUnifier.BallUnited -= onBallUnited;
        Booster.Performed -= onBoosterPerformed;
        _lastBallPopUp.Showed -= onLastBallPopUpCreated;
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
        DoVibro();
    }

    private void onBallUnited(Ball ball)
    {
        PlaySound(SoundKey.BallUnited);
        DoVibro();
    }

    private void onBoosterPerformed(BoosterType type)
    {
        PlaySound(Util.Converter.BoosterToSoundKey(type));
        DoVibro();
    }

    private void onLastBallPopUpCreated()
    {
        PlaySound(SoundKey.LastBallCreated);
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

    private void DoVibro()
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
