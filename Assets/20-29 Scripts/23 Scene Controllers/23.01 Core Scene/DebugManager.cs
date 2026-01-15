using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [SerializeField] LiveGameData liveGameData;
    [SerializeField] GameObject debugMenu;

    bool debugActivated = false;

    void Update()
    {
        if (debugActivated != liveGameData.debugOn)
        {
            debugActivated = liveGameData.debugOn;
            debugMenu.SetActive(liveGameData.debugOn);
        }
    }
}
