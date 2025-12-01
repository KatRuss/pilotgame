using UnityEngine;

public enum GRAPHICS_FLAG { LOW, HIGH }


[CreateAssetMenu(fileName = "LiveSettingsData", menuName = "LiveSettingsData")]
public class LiveSettingsData : ScriptableObject
{
    [Header("Graphics Settings")]
    public GRAPHICS_FLAG graphicsPreset;
    public bool useHighPolyModels;

    [Header("Game Settings")]
    public float gyroSensitivity;
    public float controlStickSensitivity;

    [Header("Audio Settings")]
    public bool muteAudio;
    [Range(0.0f,1.0f)] public float volumeAmount;

    [Header("Debug Settings")]
    public bool hideUI;
    public bool unlockAllItems;
    

}
