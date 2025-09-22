using UnityEngine;

[CreateAssetMenu(fileName = "LiveMissionData", menuName = "LiveMissionData", order = 0)]
public class LiveMissionData : ScriptableObject
{
    Mission activeMission;

    public void setMission(Mission mission)
    {
        activeMission = mission;
    }

    public Transform getPlayerStart()
    {
        return activeMission.getPlayerStartingTransform();
    }

    public GameObject getMissionObject()
    {
        return activeMission.missionPrefab;
    }

}