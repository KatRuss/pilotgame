using UnityEngine;

[CreateAssetMenu(fileName = "RingObjective", menuName = "Mission/Objectives/RingObjective", order = 0)]
public class RingObjective : Objective
{

    [SerializeField] int NumRingsToPassThrough;

    public override bool isObjectiveComplete(LiveGameData liveData)
    {
        return liveData.ringsPassed >= NumRingsToPassThrough;
    }

    public override string getObjectiveString()
    {
        return $"Fly through {NumRingsToPassThrough} rings";
    }
}