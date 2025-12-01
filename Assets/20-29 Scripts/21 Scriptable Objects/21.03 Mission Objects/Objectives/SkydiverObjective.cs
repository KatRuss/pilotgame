using UnityEngine;

[CreateAssetMenu(fileName = "SkydiverObjective", menuName = "Mission/Objectives/SkydiverObjective", order = 0)]
public class SkydiverObjective : Objective
{
    [SerializeField] int skydiverNum;

    public override bool isObjectiveComplete(LiveGameData liveData)
    {
        return liveData.skydiversDropped >= skydiverNum;
    }

    public override string getObjectiveString()
    {
        return $"Fly the Skydivers to {skydiverNum} locations";
    }
}