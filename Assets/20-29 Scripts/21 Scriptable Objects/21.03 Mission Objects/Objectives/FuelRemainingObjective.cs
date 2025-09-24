using UnityEngine;

[CreateAssetMenu(fileName = "FuelRemainingObjective", menuName = "Mission/Objectives/FuelRemainingObjective", order = 0)]
public class FuelRemainingObjective : Objective {
    [SerializeField] int FuelRemaining;

    public override bool isObjectiveComplete(LiveData liveData)
    {
        return liveData.fuel >= FuelRemaining && liveData.missionComplete;
    }

    public override bool isObjectiveFailed(LiveData liveData)
    {
        return liveData.fuel <= FuelRemaining;
    }

    public override string getObjectiveString()
    {
        return $"End the level with {FuelRemaining} fuel";
    }
}