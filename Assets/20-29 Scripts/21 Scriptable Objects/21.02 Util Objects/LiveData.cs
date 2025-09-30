using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "LiveData", menuName = "LiveData", order = 0)]
public class LiveData : ScriptableObject
{
    // Data regarding the game is it is being played. Mission update information, player stats, etc.
    // Should not include utility things such as scene loading information, etc. As this is just for values that change during play.

    [Header("Player Data")]
    public float throttle;
    // turn in this case is the combination of roll and yaw.
    // yaw is what the player is controlling, roll is for visual effect.
    [Tooltip("The Combination of pitch and yaw. Yaw is what the player is controlling.")]
    public float turn;
    public float pitch;
    public float currentWeight;
    public float distanceToGround;
    public float altitude;
    public float fuel;
    public float currentStallThrust;
    public bool planeStalling;

    [Header("Mission Data")]
    public Mission activeMission;
    public bool missionComplete;
    public bool missionFailed;
    public float timer;

    [Header("Objective Data")]
    public int ringsPassed;
    public bool GoldStarCollected;
    public int skydiversDropped;
    public float timeSpentTurning;

    [Header("Game Data")]
    public bool gameIsPaused;

    [Header("Progression System")]
    public int merits;

    [Header("MessageBox Info")]
    public string headerToShow;
    [TextArea(2, 2)] public string messageToShow;

    [Header("UI Info")]
    public bool showUI;
    public bool showFuel;
    public bool showTimer;

    private void OnEnable()
    {
        resetAllValues();
    }

    // Resets
    void resetAllValues()
    {
        resetPlayerData();
        resetMissionData();
        resetObjectiveData();
    }

    void resetPlayerData()
    {
        throttle = 0.0f;
        turn = 0.0f;
        pitch = 0.0f;
        currentWeight = 0.0f;
        distanceToGround = 0.0f;
        altitude = 0.0f;
        fuel = 0.0f;
        planeStalling = false;
        currentStallThrust = 0.0f;
    }

    void resetMissionData()
    {
        activeMission = null;
        missionComplete = false;
        missionFailed = false;
        timer = 0.0f;
    }

    void resetObjectiveData()
    {
        ringsPassed = 0;
        merits = 0;
        skydiversDropped = 0;
        timeSpentTurning = 0;
    }
}