using UnityEngine;

[CreateAssetMenu(fileName = "TimerObjective", menuName = "Mission/Objectives/TimerObjective", order = 0)]
public class TimerObjective : Objective
{

    [SerializeField] int timerSeconds;

    public override bool isObjectiveComplete(LiveData liveData)
    {
        return liveData.missionComplete && liveData.timer < timerSeconds;
    }
    public override bool isObjectiveFailed(LiveData liveData)
    {
        return liveData.timer > timerSeconds;
    }
    public override string getObjectiveString()
    {
        return $"Complete the mission in {timerSeconds} seconds";
    }
}