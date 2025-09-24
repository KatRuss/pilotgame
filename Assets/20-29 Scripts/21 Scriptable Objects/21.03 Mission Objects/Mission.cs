using Unity.Mathematics;
using UnityEngine;

public enum TimeOfDay
{
    Morning = 20,
    Afternoon = 80,
    Evening = -5,
    Night = -12
}

[CreateAssetMenu(fileName = "Mission", menuName = "Mission/Mission", order = 0)]
public class Mission : ScriptableObject
{
    [Header("Level Information")]
    public GameObject missionPrefab;
    public TimeOfDay timeOfDay;
    public Objective[] primaryObjectives;
    public Objective[] secondaryObjectives;

    [Header("Progression Info")]

    public bool primaryObjectiveCompleted;
    public bool[] secondayObjectivesCompleted = new bool[3];

    [Header("Debug Info")]
    public bool DEBUG_AUTO_COMPLETE;
    public bool DEBUG_AUTO_RESET;

    // Level Infomration Getters
    public Transform getPlayerStartingTransform()
    {
        return missionPrefab.transform.Find("PlayerStart");
    }


    private void OnEnable()
    {
        if (DEBUG_AUTO_COMPLETE)
        {
            primaryObjectiveCompleted = true;
            secondayObjectivesCompleted = new bool[3] { true, true, true };
        }
        if (DEBUG_AUTO_RESET)
        {
            primaryObjectiveCompleted = false;
            secondayObjectivesCompleted = new bool[3] { false, false, false };
        }
    }

    public void ResetProgression()
    {
        primaryObjectiveCompleted = false;
        secondayObjectivesCompleted = new bool[3];
    }

}