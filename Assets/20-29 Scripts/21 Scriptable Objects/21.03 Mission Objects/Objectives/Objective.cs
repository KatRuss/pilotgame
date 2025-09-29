using UnityEngine;

public abstract class Objective : ScriptableObject
{
    public abstract bool isObjectiveComplete(LiveData liveData);

    public abstract string getObjectiveString();

    // If there is a specific fail condition that is different then non-completion.
    // Default: return false, assuming there is no explicit failure condition.
    public virtual bool isObjectiveFailed(LiveData liveData)
    {
        return false;
    }

}