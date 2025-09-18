using UnityEngine;

[CreateAssetMenu(fileName = "LivePlayerData", menuName = "LivePlayerData", order = 0)]
public class LivePlayerData : ScriptableObject
{
    // A holding object to hold current player data which can be passed to mission controllers,
    // UI, and so on.

    public float throttle;


    private void OnEnable()
    {
        resetAllValues();
    }

    void resetAllValues()
    {
        throttle = 0.0f;
    }

}