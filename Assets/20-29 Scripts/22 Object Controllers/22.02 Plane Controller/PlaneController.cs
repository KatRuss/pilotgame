using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] PlaneObject plane;
    [SerializeField] LiveGameData liveData;

    float rollAngle, pitchAngle, turnAngle = 0.0f;

    // The point being the heavier the plane the less responsive it is; 
    float responseModifier = 0.0f;
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        liveData.fuel = plane.getFuelMax();
    }

    void handleThrottle()
    {
        if (liveData.throttleActionValue != 0)
        {
            liveData.throttle += plane.getAcceleration() * liveData.throttleActionValue;
            liveData.throttle = Mathf.Clamp(liveData.throttle, 0f, 100f);
        }
        if (liveData.turn != 0)
        {
            liveData.timeSpentTurning += Time.deltaTime;
        }     
    }

    void setResponseModifier()
    {
        responseModifier = liveData.currentWeight / 10.0f * plane.getResponsiveness();

    }

    void Update()
    {
        //Update Values
        liveData.currentWeight = plane.getTotalWeight(liveData.fuel);
        setResponseModifier();

        //Modify Fuel
        liveData.fuel = plane.getNewFuelLevel(liveData.fuel, liveData.throttle);

        if (liveData.fuel <= 0 && !liveData.planeStalling)
            liveData.planeStalling = true;
            liveData.currentStallThrust = rb.linearVelocity.magnitude;

        if (liveData.planeStalling)
        {
            liveData.currentStallThrust = plane.getNewStallThrust(liveData.currentStallThrust);
        }

        // Modify Altitude
        liveData.altitude = transform.position.y;

        handleThrottle();
    }

    Quaternion calculatePlaneAngles()
    {
        // Arcade roll
        rollAngle += -liveData.turn * Time.deltaTime * responseModifier * 2f;
        rollAngle = Mathf.Clamp(rollAngle, -90f, 90f);

        // Arcade Pitch
        pitchAngle += liveData.pitch * Time.deltaTime * responseModifier;
        pitchAngle = Mathf.Clamp(pitchAngle, -80, 80);

        // Arade Yaw
        turnAngle += liveData.turn * Time.deltaTime * responseModifier;

        if (liveData.turn == 0)
            rollAngle = Mathf.Lerp(rollAngle, 0f, Time.deltaTime * responseModifier * 0.05f);
        if (liveData.pitch == 0)
            pitchAngle = Mathf.Lerp(pitchAngle, 0f, Time.deltaTime * responseModifier * 0.02f);
        
        return Quaternion.Euler(pitchAngle, turnAngle, rollAngle);
    }

    void FixedUpdate()
    {
        //DistanceToGround Check
        RaycastHit groundHit;
        if (Physics.Raycast(transform.position, Vector3.down, out groundHit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, Vector3.down * groundHit.distance, Color.yellow);
            liveData.distanceToGround = groundHit.distance;
        }

        rb.mass =liveData.currentWeight;

        if (liveData.fuel > 0)
            rb.AddForce(transform.forward * plane.getThrustMaximum() * liveData.throttle);
        else
            rb.AddForce(transform.forward * liveData.currentStallThrust);

        if (liveData.distanceToGround > 3)
            transform.rotation = calculatePlaneAngles();

        //upforce and gravity only when you're either taking off or landing.
        if (liveData.distanceToGround <= 10 || rb.linearVelocity.magnitude <= 10)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * plane.getLift());
        } else
        {
            rb.useGravity = false;
        }
    }
}