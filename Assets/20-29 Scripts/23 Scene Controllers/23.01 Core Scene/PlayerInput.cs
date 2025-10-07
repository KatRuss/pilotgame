using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] LiveData liveData;
    InputAction pitchAction, turnAction, throttleAction, pauseAction;

    void Start()
    {
        pitchAction = InputSystem.actions.FindAction("pitch");
        turnAction = InputSystem.actions.FindAction("yaw");
        throttleAction = InputSystem.actions.FindAction("throttle");
        pauseAction = InputSystem.actions.FindAction("pause");
    }

    void Update()
    {
        if (liveData.playerActive)
        {
            handleInputs();
        }
    }

    void handleInputs()
    {

        liveData.pitch = pitchAction.ReadValue<float>();
        liveData.turn = turnAction.ReadValue<float>();
        liveData.throttleActionValue = throttleAction.ReadValue<float>();
        if (pauseAction.WasPressedThisFrame())
        {
            liveData.gameIsPaused = !liveData.gameIsPaused;
        }
    }
}