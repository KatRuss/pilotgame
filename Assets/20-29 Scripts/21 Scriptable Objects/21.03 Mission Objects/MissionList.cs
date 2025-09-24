using UnityEngine;

[CreateAssetMenu(fileName = "MissionList", menuName = "Mission/MissionList", order = 0)]
public class MissionList : ScriptableObject
{
    public Mission[] missions;

    public int getCompletedMerits()
    {
        int result = 0;

        foreach (Mission mission in missions)
        {
            foreach (bool secondaryObjective in mission.secondayObjectivesCompleted)
            {
                if (secondaryObjective)
                {
                    result += 1;
                }
            }
        }

        return result;
    }
    
}