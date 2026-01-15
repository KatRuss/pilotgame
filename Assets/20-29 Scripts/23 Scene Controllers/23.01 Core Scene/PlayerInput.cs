using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] LiveGameData liveData;
    InputAction pitchAction, turnAction, throttleAction, pauseAction, debugAction;

    void Start()
    {
        pitchAction = InputSystem.actions.FindAction("pitch");
        turnAction = InputSystem.actions.FindAction("yaw");
        throttleAction = InputSystem.actions.FindAction("throttle");
        pauseAction = InputSystem.actions.FindAction("pause");
        debugAction = InputSystem.actions.FindAction("debug");
    }

    void Update()
    {
        if (liveData.playerActive)
        {
            handleInputs();
        }
        handleDebug();
    }

    void handleDebug()
    {
        if (debugAction.WasPressedThisFrame())
        {
            liveData.debugOn = !liveData.debugOn;
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