using UnityEngine;

[CreateAssetMenu(fileName = "RingObjective", menuName = "Mission/Objectives/RingObjective", order = 0)]
public class RingObjective : Objective
{

    [SerializeField] int NumRingsToPassThrough;

    public override bool IsObjectiveComplete(LiveGameData liveData)
    {
        return liveData.ringsPassed >= NumRingsToPassThrough;
    }

    public override string GetObjectiveString()
    {
        return $"Fly through {NumRingsToPassThrough} rings";
    }
}