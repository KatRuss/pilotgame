using UnityEngine;

public abstract class Objective : ScriptableObject
{
    public abstract bool IsObjectiveComplete(LiveGameData liveData);

    public abstract string GetObjectiveString();

    // If there is a specific fail condition that is different then non-completion.
    // Default: return false, assuming there is no explicit failure condition.
    public virtual bool IsObjectiveFailed(LiveGameData liveData)
    {
        return false;
    }

}