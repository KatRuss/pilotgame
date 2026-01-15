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
    [Header("Menu Info")]
    public string menuName;
    [TextArea(2,2)] public string menuDescription;
    
    [Header("Level Info")]
    public GameObject missionPrefab;
    public TimeOfDay timeOfDay;
    
    [Header("Player Overides")]
    [Range(0.0f, 100.0f)] public float startingThrottle = 0.0f;

    [Header("Mission Info")]
    public Objective[] primaryObjectives;
    public Objective[] secondaryObjectives;


    [Header("Progression Info")]
    public bool[] primaryObjectiveCompleted = new bool[3];
    public bool[] secondayObjectivesCompleted = new bool[3];
    public bool[] secondaryObjectivesFailed = new bool[3];

    [Header("Debug Info")]
    public bool DEBUG_AUTO_COMPLETE;
    public bool DEBUG_AUTO_RESET;

    // Level Infomration Getters
    public Transform GetPlayerStartingTransform()
    {
        return missionPrefab.transform.Find("PlayerStart");
    }

    private void OnEnable()
    {
        if (DEBUG_AUTO_COMPLETE)
        {
            primaryObjectiveCompleted = new bool[3] { true, true, true };
            secondayObjectivesCompleted = new bool[3] { true, true, true };
            secondaryObjectivesFailed = new bool[3] { false, false, false };

        }
        if (DEBUG_AUTO_RESET)
        {
            primaryObjectiveCompleted = new bool[3] { false, false, false };
            secondayObjectivesCompleted = new bool[3] { false, false, false };
            secondaryObjectivesFailed = new bool[3] { false, false, false };
        }
    }

    public void ResetProgression()
    {
        primaryObjectiveCompleted = new bool[3];
        secondayObjectivesCompleted = new bool[3];
        secondaryObjectivesFailed = new bool[3];
    }

}