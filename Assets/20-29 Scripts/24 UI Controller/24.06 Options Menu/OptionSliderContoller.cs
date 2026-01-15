using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionSliderContoller : OptionController {
    [Header("Slider Info")]
    [SerializeField] Slider slider;

    [Header("Setting info")]
    public SliderOption settingToMonitor;

    void Start()
    {
        optionTitleLabel.text = settingToMonitor.optionTitle;
        slider.minValue = settingToMonitor.valueMin;
        slider.maxValue = settingToMonitor.valueMax;
        SetText();
    }


    public void OnClick()
    {
        settingToMonitor.SetOption((int)slider.value);
    }

    void SetText()
    {
        optionSettingLabel.text = settingToMonitor.optionToMonitor.value.ToString();
    }



}