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



    float throttle, pitch, yaw;

    float rollAngle, pitchAngle, yawAngle = 0.0f;

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
        throttleAction = InputSystem.actions.FindAction("throttle");
    }

    void handleInputs()
    {
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

    Quaternion calculatePlaneAngles()
    {
        // Arcade roll
        rollAngle += -yaw * Time.deltaTime * responseModifier * 0.3f;
        rollAngle = Mathf.Clamp(rollAngle, -60f, 69f);

        // Arcade Pitch
        pitchAngle += pitch * Time.deltaTime * responseModifier * 0.3f;
        pitchAngle = Mathf.Clamp(pitchAngle, -80, 80);

        // Arade Yaw
        yawAngle += yaw * Time.deltaTime * responseModifier * 0.3f;

        Debug.Log(rollAngle + " " + pitchAngle + " " + yawAngle);

        if (yaw == 0)
            rollAngle = Mathf.Lerp(rollAngle, 0f, Time.deltaTime * responseModifier * 0.02f);
        if (pitch == 0)
            pitchAngle = Mathf.Lerp(pitchAngle, 0f, Time.deltaTime * responseModifier * 0.02f);
        
        return Quaternion.Euler(pitchAngle, yawAngle, rollAngle);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrustMaximum * throttle);

        transform.rotation = calculatePlaneAngles();

        //upforce and gravity only when you're attempting to land
        if (transform.position.y <= 10)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * lift);
        } else
        {
            rb.useGravity = false;
        }
    }
}
