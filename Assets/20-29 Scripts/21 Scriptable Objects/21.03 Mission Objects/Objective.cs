using UnityEngine;

public abstract class Objective : ScriptableObject
{
    public abstract bool isObjectiveComplete(LiveMissionData liveMissionData, LivePlayerData livePlayerData);


}