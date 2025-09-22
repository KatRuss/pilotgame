using UnityEngine;

public abstract class Objective : ScriptableObject
{
    public abstract bool isObjectiveComplete(LiveMissionData liveMissionData, LivePlayerData livePlayerData);

    public abstract string getObjectiveString();

    // If there is a specific fail condition that is different then non-completion.
    public abstract bool isObjectiveFailed(LiveMissionData liveMissionData, LivePlayerData livePlayerData);

}