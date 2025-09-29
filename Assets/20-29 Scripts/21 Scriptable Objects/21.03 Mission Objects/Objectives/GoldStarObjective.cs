using UnityEngine;

[CreateAssetMenu(fileName = "GoldStarObjective", menuName = "Mission/Objectives/GoldStarObjective", order = 0)]
public class GoldStarObjective : Objective
{
    public override bool isObjectiveComplete(LiveData liveData)
    {
        return liveData.GoldStarCollected;
    }

    public override bool isObjectiveFailed(LiveData liveData)
    {
        return false;
    }

    public override string getObjectiveString()
    {
        return "Find the Gold Star!";
    }
}