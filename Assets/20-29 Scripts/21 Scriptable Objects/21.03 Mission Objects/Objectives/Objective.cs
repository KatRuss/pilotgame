using UnityEngine;

public abstract class Objective : ScriptableObject
{
    public abstract bool isObjectiveComplete(LiveData liveData);

    public abstract string getObjectiveString();

    // If there is a specific fail condition that is different then non-completion.
    public abstract bool isObjectiveFailed(LiveData liveData);

}