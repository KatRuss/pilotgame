using UnityEngine;

public enum TimeOfDay
{
    Morning = 20,
    Afternoon = 80,
    Evening = -5,
    Night = -12
}

[CreateAssetMenu(fileName = "MissionLevelInfo", menuName = "Mission/New Mission", order = 0)]
public class MissionLevelInfo : ScriptableObject
{
    public GameObject missionPrefab;
    public TimeOfDay timeOfDay;
    public Objective[] primaryObjectives;
    public Objective[] secondaryObjectives;

    public Transform getPlayerStartingTransform()
    {
        return missionPrefab.transform.Find("PlayerStart");
    }
}