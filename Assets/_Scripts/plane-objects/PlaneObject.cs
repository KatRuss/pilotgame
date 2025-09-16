using UnityEngine;

[CreateAssetMenu(fileName = "New Plane", menuName = "Plane/Plane", order = 0)]
public class PlaneObject : ScriptableObject
{
    /* This object contains the plane information. Mainly the name, description, and parts objects.
    Also inclused the getters for plane physics calculations */
    public string planeName;
    [SerializeField] PlaneBodyObject planeBody;
    [SerializeField] PlaneEngineObject planeEngine;
    [SerializeField] PlaneFuelTankObject planeFuelTank;

    public float getCurrentTargetThrust(float throttle)
    {
        float cThrottle = Mathf.Clamp(throttle, 0.0f, 1.0f);
        return Mathf.SmoothStep(0.0f, planeEngine.thrustMaximum, cThrottle);
    }

    public float getTotalWeight(float currentFuel)
    {
        return planeEngine.weight +
                planeBody.weight +
                planeFuelTank.baseWeight +
                (planeFuelTank.fuelWeightPerLitre * currentFuel);
    }
    public float getResponsiveness()
    {
        return planeBody.responsiveness;
    }

    public float getAcceleration()
    {
        return planeEngine.accelerationForce;
    }

    public float getThrustMaximum()
    {
        return planeEngine.thrustMaximum;
    }

    public float getLift()
    {
        return planeBody.lift;
    }
}