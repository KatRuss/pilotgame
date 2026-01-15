using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] LiveGameData liveData;

    [Header("Menu Objects")]
    [SerializeField] GameObject mainMenu;

    [Header("Options Menu Objects")]
    [SerializeField] GameObject optionsMenu;

    [Header("Level Select Objects")]
    [SerializeField] GameObject levelCard;
    [SerializeField] GameObject levelSelectMenu;
    [SerializeField] GameObject levelListHolder;

    [Header("Hanger Objects")]
    [SerializeField] GameObject hangerMenu;
    [SerializeField] TextMeshProUGUI planeBodyName;
    [SerializeField] TextMeshProUGUI planeEngineName;
    [SerializeField] TextMeshProUGUI planeFuelName;

    List<PlaneBodyObject> planeBodies;
    List<PlaneEngineObject> planeEngines;
    List<PlaneFuelTankObject> planeFuelTanks;
    int planeBodyIndex = 0;
    int planeEngineIndex = 0;
    int planeFuelTankIndex = 0;

    [Header("Mission List")]
    [SerializeField] MissionList missionList;

    [Header("Progression List")]
    [SerializeField] ProgressionList progressionList;

    private void Awake()
    {
        populateLevelList();
        populateUnlockLists();
        mainMenu.SetActive(true);
    }

    void Start()
    {
        setUnlockLists();
    }

    void Update()
    {
        planeBodyName.text = planeBodies[planeBodyIndex].partName;
        planeEngineName.text = planeEngines[planeEngineIndex].partName;
        planeFuelName.text = planeFuelTanks[planeFuelTankIndex].partName;
    }

    public void populateLevelList()
    {
        for (int i = 0; i < missionList.missions.Length; i++)
        {
            var card = Instantiate(levelCard, levelListHolder.transform);
            card.GetComponent<LevelButtonController>().missionNumber = i;
        }
    }

    public void showLevelMenu()
    {
        levelSelectMenu.SetActive(true);
        hangerMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void showMainMenu()
    {
        levelSelectMenu.SetActive(false);
        hangerMenu.SetActive(false);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void showHangerManu()
    {
        levelSelectMenu.SetActive(false);
        hangerMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void showOptionsMenu()
    {
        levelSelectMenu.SetActive(false);
        hangerMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void playLevel()
    {
        Debug.Log("play level");
    }

    void populateUnlockLists()
    {
        planeBodies = getUnlockedBodies();
        planeEngines = getUnlockedEngines();
        planeFuelTanks = getUnlockedFuelTanks();
    }

    public void moveBodyIndex(int move)
    {
        if (planeBodyIndex + move > planeBodies.Count - 1)
        {
            planeBodyIndex = 0;
        }
        else if (planeBodyIndex + move < 0)
        {
            planeBodyIndex = Math.Max(0, planeBodies.Count - 1);
        }
        else
        {
            planeBodyIndex += move;
        }
        updatePlayerBody();
    }

    public void updatePlayerEngine()
        { liveData.playerPlane.SetPlaneEngine(planeEngines[planeEngineIndex]); }

    public void updatePlayerFuelTank()
        {liveData.playerPlane.SetPlaneFuelTank(planeFuelTanks[planeEngineIndex]);}

    public void updatePlayerBody()
        {liveData.playerPlane.SetPlaneBody(planeBodies[planeBodyIndex]);}

    public void moveEngineIndex(int move)
    {
        if (planeEngineIndex + move > planeEngines.Count - 1)
        {
            planeEngineIndex = 0;
        }
        else if (planeEngineIndex + move < 0)
        {
            planeEngineIndex = Math.Max(0, planeEngines.Count - 1);
        }
        else
        {
            planeEngineIndex += move;
        }
        updatePlayerEngine();
    }

    public void moveFuelTankIndex(int move)
    {
        if (planeFuelTankIndex + move > planeFuelTanks.Count - 1)
        {
            planeFuelTankIndex = 0;
        }
        else if (planeFuelTankIndex + move < 0)
        {
            planeBodyIndex = Math.Max(0, planeFuelTanks.Count - 1);
        }
        else
        {
            planeFuelTankIndex += move;
        }
        updatePlayerFuelTank();
    }

    void setUnlockLists()
    {
        PlaneEngineObject usedEngine = liveData.playerPlane.GetPlaneEngine();
        PlaneBodyObject usedBody = liveData.playerPlane.GetPlaneBody();
        PlaneFuelTankObject usedFuelTank = liveData.playerPlane.GetPlaneFuelTank();

        planeEngineIndex = planeEngines.IndexOf(usedEngine);
        planeBodyIndex = planeBodies.IndexOf(usedBody);
        planeFuelTankIndex = planeFuelTanks.IndexOf(usedFuelTank);
    }

    List<PlaneEngineObject> getUnlockedEngines()
    {
        List<PlaneEngineObject> result = new();

        foreach (var part in progressionList.items)
        {
            if (part.planePart is PlaneEngineObject && part.unlocked)
            {
                result.Add((PlaneEngineObject)part.planePart);
            }
        }

        return result;
    }

    List<PlaneBodyObject> getUnlockedBodies()
    {
        List<PlaneBodyObject> result = new();

        foreach (var part in progressionList.items)
        {
            if (part.planePart is PlaneBodyObject && part.unlocked)
            {
                result.Add((PlaneBodyObject)part.planePart);
            }
        }

        return result;
    }

    List<PlaneFuelTankObject> getUnlockedFuelTanks()
    {
        List<PlaneFuelTankObject> result = new();

        foreach (var part in progressionList.items)
        {
            if (part.planePart is PlaneFuelTankObject && part.unlocked)
            {
                result.Add((PlaneFuelTankObject)part.planePart);
            }
        }

        return result;
    }
}