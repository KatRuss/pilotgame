using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "New SliderOption", menuName = "Options/SliderOption", order = 0)]
public class SliderOption : Option {
    [Header("Settings Info")]
    public SharedInt optionToMonitor;
    public int valueMin;
    public int valueMax;

    public override void SetOption(int value) { optionToMonitor.value = math.clamp(value,valueMin,valueMax); }

}