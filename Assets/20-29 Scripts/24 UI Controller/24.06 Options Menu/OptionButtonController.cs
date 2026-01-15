using UnityEngine;
using UnityEngine.UI;

public class OptionButtonController : OptionController
{

    [Header("Setting info")]
    public BoolOption settingToMonitor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionTitleLabel.text = settingToMonitor.optionTitle;
        SetText();
    }

    public void OnClick()
    {
        settingToMonitor.setOption(0);
        SetText();
    }

    void SetText()
    {
        optionSettingLabel.text = settingToMonitor.optionToMonitor.value ? "On" : "Off";
    }
}
