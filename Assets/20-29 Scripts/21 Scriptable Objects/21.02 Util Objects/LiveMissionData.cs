using UnityEngine;

[CreateAssetMenu(fileName = "LiveMissionData", menuName = "LiveMissionData", order = 0)]
public class LiveMissionData : ScriptableObject
{
    public Mission activeMission;

    public int ringsPassed;

    void OnEnable()
    {
        resetAllValues();
    }

    void resetAllValues()
    {
        ringsPassed = 0;
    }
}