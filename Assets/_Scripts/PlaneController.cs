using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlaneController : MonoBehaviour
{


    // plane thrust and control stats
    public float throttleIncrement = 0.1f;
    public float throttleMaximum = 100f;
    public float thrustMaximum = 200f;
    public float responsiveness = 10f;
    public float lift = 135f;

    // Fuel tank stats



    float throttle, pitch, roll, yaw;

    Rigidbody rb;

    InputAction pitchAction, rollAction, yawAction, throttleAction;

    float responseModifier
    {
        get
        {
            return rb.mass / 10f * responsiveness;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        getInputActions();
    }

    void getInputActions()
    {
        pitchAction = InputSystem.actions.FindAction("pitch");
        yawAction = InputSystem.actions.FindAction("yaw");
        rollAction = InputSystem.actions.FindAction("roll");
        throttleAction = InputSystem.actions.FindAction("throttle");
    }

    void handleInputs()
    {
        roll = rollAction.ReadValue<float>();
        pitch = pitchAction.ReadValue<float>();
        yaw = yawAction.ReadValue<float>();


        var throttleActionValue = throttleAction.ReadValue<float>();
        // Get Throttle
        if (throttleActionValue != 0)
        {
            throttle += throttleIncrement * throttleActionValue;
            throttle = Mathf.Clamp(throttle, 0f, throttleMaximum);
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrustMaximum * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);

        rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * lift);
    }
}
