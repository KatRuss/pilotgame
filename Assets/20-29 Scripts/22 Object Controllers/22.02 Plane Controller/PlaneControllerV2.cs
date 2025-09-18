using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneControllerV2 : MonoBehaviour
{
    [SerializeField] PlaneObject plane;
    [SerializeField] LivePlayerData livePlayerData;

    // turn in this case is the combination of roll and yaw.
    // yaw is what the player is controlling, roll is for visual effect.
    float pitch, turn;
    float rollAngle, pitchAngle, turnAngle = 0.0f;

    float currentWeight;
    float currentFuel;
    float distanceToGround;


    // The point being the heavier the plane the less responsive it is; 
    float responseModifier = 0.0f;
    


    Rigidbody rb;
    InputAction pitchAction, turnAction, throttleAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        getInputActions();
    }

    void getInputActions()
    {
        pitchAction = InputSystem.actions.FindAction("pitch");
        turnAction = InputSystem.actions.FindAction("yaw");
        throttleAction = InputSystem.actions.FindAction("throttle");
    }

    void handleInputs()
    {
        pitch = pitchAction.ReadValue<float>();
        turn = turnAction.ReadValue<float>();


        var throttleActionValue = throttleAction.ReadValue<float>();
        // Get Throttle
        if (throttleActionValue != 0)
        {
            livePlayerData.throttle += plane.getAcceleration() * throttleActionValue;
            livePlayerData.throttle = Mathf.Clamp(livePlayerData.throttle, 0f, 100f);
        }
    }

    void setResponseModifier()
    {
        responseModifier = currentWeight / 10.0f * plane.getResponsiveness();

    }

    void Update()
    {
        //Update Values
        currentWeight = plane.getTotalWeight(currentFuel);
        setResponseModifier();

        //Get Player Input
        handleInputs();
    }

    Quaternion calculatePlaneAngles()
    {
        // Arcade roll
        rollAngle += -turn * Time.deltaTime * responseModifier * 2f;
        rollAngle = Mathf.Clamp(rollAngle, -90f, 90f);

        // Arcade Pitch
        pitchAngle += pitch * Time.deltaTime * responseModifier;
        pitchAngle = Mathf.Clamp(pitchAngle, -80, 80);

        // Arade Yaw
        turnAngle += turn * Time.deltaTime * responseModifier;

        if (turn == 0)
            rollAngle = Mathf.Lerp(rollAngle, 0f, Time.deltaTime * responseModifier * 0.05f);
        if (pitch == 0)
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
            distanceToGround = groundHit.distance;
        }

        rb.mass = currentWeight;
        
        rb.AddForce(transform.forward * plane.getThrustMaximum() * livePlayerData.throttle);

        if (distanceToGround > 3)
            transform.rotation = calculatePlaneAngles();

        //upforce and gravity only when you're attempting to land
        if (distanceToGround <= 10 || rb.linearVelocity.magnitude <= 10)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * plane.getLift());
        } else
        {
            rb.useGravity = false;
        }
    }
}