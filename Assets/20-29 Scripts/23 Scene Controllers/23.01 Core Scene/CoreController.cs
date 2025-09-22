using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreController : MonoBehaviour
{
    // Handles loading scenes, destorying them, and exiting out of the game
    // Additionally, handles anything that must be 

    [SerializeField] LiveMissionData missionData;
    [SerializeField] Mission[] missions;

    void Start()
    {
        LoadGameScene(missions[0]);
    }

    void LoadGameScene(Mission activeMission)
    {
        // Load Map
        SceneManager.LoadScene("S-Foxtail-Map", LoadSceneMode.Additive);

        // Load Mission Controller, give it the desired mission
        SceneManager.LoadScene("S-Mission-Controller", LoadSceneMode.Additive);
        missionData.setMission(activeMission);

        // Load Gameplay UI
        SceneManager.LoadScene("S-UI-Gameplay", LoadSceneMode.Additive);
    }


}
