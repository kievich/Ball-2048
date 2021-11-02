using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSwitch : MonoBehaviour
{
    [SerializeField] private Texture2D _enableImage;
    [SerializeField] private Texture2D _disableImage;
    [SerializeField] private SettingOption _settingOption;
    public static event Action<SettingOption> OptionChanged;
    private RawImage _rawImage;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
        GetComponent<Button>().onClick.AddListener(onClick);
        UpdateEnableStatus();
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(onClick);
    }

    private void onClick()
    {
        AppData.SwitchSetting(_settingOption);
        UpdateEnableStatus();
        OptionChanged?.Invoke(_settingOption);
    }

    private void UpdateEnableStatus()
    {
        SetEnableStatus(AppData.GetSettingValue(_settingOption));
    }

    private void SetEnableStatus(bool status)
    {
        if (status)
            _rawImage.texture = _enableImage;
        else
            _rawImage.texture = _disableImage;
    }
}
