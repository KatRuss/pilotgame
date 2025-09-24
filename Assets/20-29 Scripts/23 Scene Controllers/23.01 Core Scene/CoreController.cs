using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreController : MonoBehaviour
{
    // Handles loading scenes, destorying them, and exiting out of the game
    // Additionally, handles anything that must be 

    [SerializeField] LiveMissionData missionData;
    [SerializeField] SharedInt levelToLoad; //Reference of what misison should be loaded.
    [SerializeField] MissionLevelInfo[] missions;

    readonly string[] LevelScenes = { "S-Foxtail-Gameplay", "S-Mission-Controller", "S-UI-Gameplay" };
    readonly string[] MenuScenes = { "S-Foxtail-MainMenu", "S-UI-MainMenu" };

    int loadedLevel = -1;


    void Start()
    {
        LoadMainMenu();
    }

    private void Update()
    {
        // Level Loading
        if (levelToLoad.value != loadedLevel)
        {
            if (levelToLoad.value == -1)
            {
                LoadMainMenu();
            }
            else
            {
                LoadGameScene(missions[levelToLoad.value]);
            }
            loadedLevel = levelToLoad.value;
        }
    }

    void LoadSceneBatch(string[] sceneList)
    {
        foreach (string scene in sceneList)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    void UnloadSceneBatch(string[] sceneList)
    {
        foreach (string scene in sceneList)
        {
            if (SceneManager.GetSceneByName(scene).IsValid())
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    void LoadMainMenu()
    {
        UnloadGameScene();
        LoadSceneBatch(MenuScenes);
    }

    void LoadGameScene(MissionLevelInfo activeMission)
    {
        unloadMainMenu();
        LoadSceneBatch(LevelScenes);
        missionData.activeMission = activeMission;
    }

    void UnloadGameScene()
    {
        // If Scenes exist, you should unload them
        UnloadSceneBatch(LevelScenes);
        missionData.activeMission = null;
    }
    
    void unloadMainMenu() { UnloadSceneBatch(MenuScenes); }
}
