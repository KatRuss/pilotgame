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
                planeFuelTank.weight +
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

    public float getFuelMax()
    {
        return planeFuelTank.fuelMaximum;
    }

    public float getNewFuelLevel(float currentFuel, float currentThrottle)
    {
        return Mathf.Clamp(
            currentFuel - ((planeEngine.fuelBurnRate + planeEngine.fuelBurnThrottleRate * currentThrottle) * Time.deltaTime),
            0,
            1000
        );
    }

    public float getNewStallThrust(float currentStallThrust)
    {
        return Mathf.Clamp(
            currentStallThrust - (planeBody.stallThrustBurnRate * Time.deltaTime),
            planeBody.minimumStallThrust,
            1000
        );
    }

    public PlaneBodyObject GetPlaneBody()
    {
        return planeBody;
    }

    public void SetPlaneBody(PlaneBodyObject pb)
    {
        planeBody = pb;
    }

    public PlaneEngineObject GetPlaneEngine()
    {
        return planeEngine;
    }

    public void SetPlaneEngine(PlaneEngineObject pb)
    {
        planeEngine = pb;
    }

    public PlaneFuelTankObject GetPlaneFuelTank()
    {
        return planeFuelTank;
    }

    public void setPlaneFuelTank(PlaneFuelTankObject pf)
    {
        planeFuelTank = pf;
    }
}