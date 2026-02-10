using UnityEngine;

[CreateAssetMenu(fileName = "PlaneStats", menuName = "Plane/PlaneStats")]
public class PlaneStats : ScriptableObject
{
    [Header("Body Stats")]
    public float weight;
    public float turnResponsiveness;
    public float uplift;
    public float minimumStallThrust;
    public float stallThrustBurnRate;

    [Header("Engine Stats")]
    [Tooltip("The maximum thrust the engine can supply to the plane")]
    public float thrustMaximum;
    [Tooltip("The Speed of acceleration")]
    public float accelerationForce;
    [Tooltip("The Speed of deceleration")]
    public float decelerationForce;
    [Tooltip("base rate at which it burns fuel while idling")]
    public float fuelBurnRate;
    [Tooltip("rate at which it burns fuels depending on speed")]
    public float fuelBurnThrottleRate;

    [Header("Fuel Tank Stats")]
    public float fuelWeightPerLitre;

    public float GetTotalWeight(float currentFuel)
    {
        return weight + (fuelWeightPerLitre * currentFuel);
    }

    public float GetNewFuelLevel(float currentFuel, float currentThrottle)
    {
        return Mathf.Clamp(
            currentFuel - ((fuelBurnRate + fuelBurnThrottleRate * currentThrottle) * Time.deltaTime),
            0,
            1000
        );
    }

}
