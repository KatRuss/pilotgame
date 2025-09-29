using UnityEngine;

public enum AltitudeType {
    Above,
    Under
}

[CreateAssetMenu(fileName = "AltitudeObjective", menuName = "Mission/Objectives/AltitudeObjective", order = 0)]
public class AltitudeObjective : Objective {
    [SerializeField] AltitudeType altitudeType;
    [SerializeField] int desiredAltitude;
    [SerializeField] int warningBufferSeconds;

    public override bool isObjectiveComplete(LiveData liveData)
    {
        return liveData.missionComplete && !isObjectiveFailed(liveData);
    }

    public override bool isObjectiveFailed(LiveData liveData)
    {
        if (altitudeType == AltitudeType.Above)
        {
            return liveData.altitude < desiredAltitude;
        }
        else
        {
            return liveData.altitude > desiredAltitude;
        }
    }

    public override string getObjectiveString()
    {
        return $"Don't go {(altitudeType == AltitudeType.Above ? "above" : "under")} {desiredAltitude} altitude.";
    }
}