using System.Data.Common;
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
        liveData.fuel = plane.GetFuelMax();
        rollAngle = transform.eulerAngles.z;
        pitchAngle = transform.eulerAngles.x;
        turnAngle = transform.eulerAngles.y;
    }

    void HandleThrottle()
    {
        if (liveData.throttleActionValue != 0)
        {
            liveData.throttle += plane.GetAcceleration() * liveData.throttleActionValue;
            liveData.throttle = Mathf.Clamp(liveData.throttle, 0f, 100f);
        }
        if (liveData.turn != 0)
        {
            liveData.timeSpentTurning += Time.deltaTime;
        }     
    }

    void SetResponseModifier()
    {
        responseModifier = liveData.currentWeight / 10.0f * plane.GetResponsiveness();

    }

    void Update()
    {
        //Update Values
        liveData.currentWeight = plane.GetTotalWeight(liveData.fuel);
        SetResponseModifier();

        //Modify Fuel
        liveData.fuel = plane.GetNewFuelLevel(liveData.fuel, liveData.throttle);

        // Plane Stalling
        liveData.currentStallThrust = Mathf.Lerp(liveData.currentStallThrust, plane.GetThrustMaximum() * liveData.throttle, Time.deltaTime * 3);

        liveData.planeStalling = (liveData.fuel <= 0 || liveData.throttle == 0) && liveData.distanceToGround >= 10.0;

        if (liveData.planeStalling)
            liveData.currentStallThrust = Mathf.Lerp(liveData.currentStallThrust, plane.GetStallMinimum(), Time.deltaTime * plane.GetStallBurnRate());

        // Modify Altitude
        liveData.altitude = transform.position.y;

        HandleThrottle();
    }

    Quaternion CalculatePlaneAngles()
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

        if (!liveData.planeStalling)
        {
            print(plane.GetThrustMaximum() * liveData.throttle);
            rb.AddForce(liveData.throttle * plane.GetThrustMaximum() * transform.forward);
   
        }
         else
            rb.AddForce(transform.forward * liveData.currentStallThrust);

        if (liveData.distanceToGround > 3)
            transform.rotation = CalculatePlaneAngles();

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