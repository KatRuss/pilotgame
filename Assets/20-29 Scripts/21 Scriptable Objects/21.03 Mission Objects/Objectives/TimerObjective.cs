using UnityEngine;

[CreateAssetMenu(fileName = "TimerObjective", menuName = "Mission/Objectives/TimerObjective", order = 0)]
public class TimerObjective : Objective
{

    [SerializeField] int timerSeconds;
    [Tooltip("Enable when you want staying on the map for an amount of time to be a success critera")][SerializeField] bool completeWhenElapsed;

    public override bool isObjectiveComplete(LiveGameData liveData)
    {
        if (completeWhenElapsed)
        {
            return liveData.timer >= timerSeconds;
        }
        else
        {
            return liveData.missionComplete && liveData.timer < timerSeconds;
        }
    }
    public override bool isObjectiveFailed(LiveGameData liveData)
    {
        if (completeWhenElapsed)
        {
            return false;
        }
        else
        {
            return liveData.timer > timerSeconds;    
        }
    }
    public override string getObjectiveString()
    {
        return $"{(completeWhenElapsed ? "Fly around for {timerSeconds} seconds" : "Complete the mission in {timerSeconds} seconds")}";
    }
}