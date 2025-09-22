using UnityEngine;

[CreateAssetMenu(fileName = "FuelRemainingObjective", menuName = "Mission/Objectives/FuelRemainingObjective", order = 0)]
public class FuelRemainingObjective : Objective {
    [SerializeField] int FuelRemaining;

    public override bool isObjectiveComplete(LiveMissionData liveMissionData, LivePlayerData livePlayerData)
    {
        return livePlayerData.fuel >= FuelRemaining;
    }

    public override bool isObjectiveFailed(LiveMissionData liveMissionData, LivePlayerData livePlayerData)
    {
        return livePlayerData.fuel <= FuelRemaining;
    }

    public override string getObjectiveString()
    {
        return $"End the level with {FuelRemaining} fuel";
    }
}