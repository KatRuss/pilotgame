using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LiveData", menuName = "LiveData", order = 0)]
public class LiveData : ScriptableObject
{
    // Data regarding the game is it is being played. Mission update information, player stats, etc.
    // Should not include utility things such as scene loading information, etc. As this is just for values that change during play.

    [Header("Player Data")]
    public float throttle;
    public float altitude;
    public float fuel;
    public float currentStallThrust;
    public bool planeStalling;

    [Header("Mission Data")]
    public Mission activeMission;
    public bool missionComplete;
    public bool missionFailed;

    [Header("Objective Data")]
    public int ringsPassed;

    [Header("Game Data")]
    public bool gameIsPaused;

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
    }

    void resetObjectiveData()
    {
        ringsPassed = 0;
    }
}