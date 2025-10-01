using UnityEngine;

public class ProgressionController : MonoBehaviour
{
    [SerializeField] ProgressionList progressionList;
    [SerializeField] MissionList missionList;
    [SerializeField] LiveData liveData;

    private void Update()
    {
        if (liveData.missionComplete || liveData.missionFailed)
        {
            liveData.merits = GetCompletedMerits();
            HandleUnlocks();
        }
    }

    public void HandleUnlocks()
    {
        foreach (var item in progressionList.items)
        {
            if (liveData.merits >= item.meritsToUnlock)
            {
                item.unlocked = true;
            }
        }
    }

    public int GetCompletedMerits()
    {
        int result = 0;

        foreach (Mission mission in missionList.missions)
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