using UnityEngine;

public enum AltitudeType {
    Above,
    Under
}

[CreateAssetMenu(fileName = "AltitudeObjective", menuName = "Mission/Objectives/AltitudeObjective", order = 0)]
public class AltitudeObjective : Objective {
    [SerializeField] AltitudeType altitudeType;
    [SerializeField] int desiredAltitude;
    int warningBufferSeconds = 10;
    float timer = 0f;
    bool failed;

    void OnEnable()
    {
        failed = false;
        timer = 0.0f;
    }

    public override bool isObjectiveComplete(LiveGameData liveData)
    {
        return liveData.missionComplete && !failed;
    }

    public override bool isObjectiveFailed(LiveGameData liveData)
    {
        if (failed)
            return true;

        // If not failed, check if failing
        if ((altitudeType == AltitudeType.Above && liveData.altitude < desiredAltitude) ||
            (altitudeType == AltitudeType.Under && liveData.altitude > desiredAltitude))
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }

        if (timer >= warningBufferSeconds)
            failed = true;

        return false;
    }

    public override string getObjectiveString()
    {
        return $"Don't go {(altitudeType == AltitudeType.Above ? "above" : "under")} {desiredAltitude} altitude.";
    }
}