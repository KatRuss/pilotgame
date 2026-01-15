using UnityEngine;

[CreateAssetMenu(fileName = "New SharedBool", menuName = "Util/SharedBool", order = 0)]
public class SharedBool : ScriptableObject
{
    [SerializeField] bool defaultValue = false;
    [SerializeField] bool resetOnStartup = false;
    public bool value;

    void OnEnable(){ if (resetOnStartup) ResetValue(); } 
    void ResetValue() { value = defaultValue; } 

}
