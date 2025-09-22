using UnityEngine;

[CreateAssetMenu(fileName = "RingObjective", menuName = "Mission/Objectives/RingObjective", order = 0)]
public class RingObjective : Objective
{

    [SerializeField] int NumRingsToPassThrough;

    public override bool isObjectiveComplete(LiveMissionData liveMissionData, LivePlayerData livePlayerData)
    {
        return liveMissionData.ringsPassed >= NumRingsToPassThrough;
    }

    public override bool isObjectiveFailed(LiveMissionData liveMissionData, LivePlayerData livePlayerData) { return false; }

    public override string getObjectiveString()
    {
        return $"Fly through {NumRingsToPassThrough} rings";
    }
}