using UnityEngine;

[CreateAssetMenu(fileName = "New Plane Engine", menuName = "Plane/Plane Engine", order = 0)]
public class PlaneEngineObject : PlanePart
{
    /* This object contains the engine stats attached to a given plane. Thrust, increments, etc. */

    [Tooltip("The maximum thrust the engine can supply to the plane")]
    public float thrustMaximum;

    [Tooltip("The Speed of acceleration")]
    public float accelerationForce;

    [Tooltip("The Speed of deceleration")]
    public float decelerationForce;

    [Tooltip("base rate at which it burns fuel")]
    public float fuelBurnRate;

    [Tooltip("rate at which it burns fuels depending on speed")]
    public float fuelBurnThrottleRate;
}