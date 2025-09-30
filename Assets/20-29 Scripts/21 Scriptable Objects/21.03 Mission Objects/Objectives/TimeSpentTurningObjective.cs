using UnityEngine;

[CreateAssetMenu(fileName = "TimeSpentTurningObjective", menuName = "Mission/Objectives/TimeSpentTurningObjective", order = 0)]
public class TimeSpentTurningObjective : Objective
{

    [SerializeField] int turnTimeSeconds;

    public override bool isObjectiveComplete(LiveData liveData)
    {
        return liveData.timeSpentTurning >= turnTimeSeconds;
    }

    public override string getObjectiveString()
    {
        return $"Turn for a total of {turnTimeSeconds} seconds";
    }
}