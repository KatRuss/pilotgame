using UnityEngine;

[CreateAssetMenu(fileName = "FuelRemainingObjective", menuName = "Mission/Objectives/FuelRemainingObjective", order = 0)]
public class FuelRemainingObjective : Objective {
    [SerializeField] int FuelRemaining;

    public override bool IsObjectiveComplete(LiveGameData liveData)
    {
        return liveData.fuel >= FuelRemaining && liveData.missionComplete;
    }

    public override bool IsObjectiveFailed(LiveGameData liveData)
    {
        return liveData.fuel <= FuelRemaining;
    }

    public override string GetObjectiveString()
    {
        return $"End the level with {FuelRemaining} fuel";
    }
}