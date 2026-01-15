using UnityEngine;

[CreateAssetMenu(fileName = "New BoolOption", menuName = "Options/BoolOption", order = 0)]
public class BoolOption : Option {
    [Header("Settings Info")]
    public SharedBool optionToMonitor;

    public override void setOption(int value) { optionToMonitor.value = !optionToMonitor.value; }
}