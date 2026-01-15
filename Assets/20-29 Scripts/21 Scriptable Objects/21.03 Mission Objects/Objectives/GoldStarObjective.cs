using UnityEngine;

[CreateAssetMenu(fileName = "GoldStarObjective", menuName = "Mission/Objectives/GoldStarObjective", order = 0)]
public class GoldStarObjective : Objective
{
    public override bool IsObjectiveComplete(LiveGameData liveData)
    {
        return liveData.GoldStarCollected;
    }

    public override string GetObjectiveString()
    {
        return "Find the Gold Star!";
    }
}