using UnityEngine;

[CreateAssetMenu(fileName = "LiveMissionData", menuName = "LiveMissionData", order = 0)]
public class LiveMissionData : ScriptableObject
{
    public MissionLevelInfo activeMission;

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