using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "LivePlayerData", menuName = "LivePlayerData", order = 0)]
public class LivePlayerData : ScriptableObject
{
    // A holding object to hold current player data which can be passed to mission controllers,
    // UI, and so on.

    public float throttle;
    public float altitude;
    public float fuel;
    public float currentStallThrust;

    private void OnEnable()
    {
        resetAllValues();
    }

    void resetAllValues()
    {
        throttle = 0.0f;
        altitude = 0.0f;
        fuel = 0.0f;
    }

}