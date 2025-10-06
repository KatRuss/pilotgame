using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;
public class MissionController : MonoBehaviour
{
    [SerializeField] LiveData liveData;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;

    bool missionBegin = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    void Start()
    {
        //liveData.throttle = liveData.activeMission.startingThrottle;

        SetUpLevel();
    }

    void SetUpLevel()
    {
        Scene tempMissionScene = SceneManager.CreateScene("S-Mission-Temp");
        GameObject level = Instantiate(liveData.activeMission.missionPrefab);
        GameObject camera = Instantiate(cameraObject);

        SceneManager.MoveGameObjectToScene(level, tempMissionScene);
        SceneManager.MoveGameObjectToScene(camera, tempMissionScene);

        if (missionBegin)
        {
            SpawnPlayer(camera);
        }
    }

    void SpawnPlayer(GameObject cam)
    {
        GameObject player = Instantiate(playerObject, liveData.activeMission.getPlayerStartingTransform().position, Quaternion.identity);
        cam.GetComponent<CameraController>().addPov(player.transform.Find("CameraPosition"), true);

        Scene playerScene = SceneManager.CreateScene("S-Player-Temp");
        SceneManager.MoveGameObjectToScene(player,playerScene);
    }

    void Update()
    {
        if (!liveData.missionFailed && !liveData.missionComplete)
        {
            PrimaryMissionCheck();
            SecondaryMissionCheck();
        }

        liveData.timer += Time.deltaTime;
    }

    void PrimaryMissionCheck()
    {
        for (int i = 0; i < liveData.activeMission.primaryObjectives.Length; i++)
        {
            if (!IsMissionFailed())
            {
                if (IsMissionComplete())
                {
                    liveData.missionComplete = true;
                }
            }
            else
            {
                Debug.Log("mission failed");
                liveData.missionFailed = true;
            }
        }

    }

    void SecondaryMissionCheck()
    {
        for (int i = 0; i < liveData.activeMission.secondaryObjectives.Length; i++)
        {
            if (!liveData.activeMission.secondaryObjectives[i].isObjectiveFailed(liveData))
            {
                if (liveData.activeMission.secondaryObjectives[i].isObjectiveComplete(liveData) && !liveData.activeMission.secondaryObjectivesFailed[i])
                {
                    liveData.activeMission.secondayObjectivesCompleted[i] = true;
                }
            }
            else
            {
                liveData.activeMission.secondaryObjectivesFailed[i] = true;
            }
        }
    }

    public bool IsMissionFailed()
    {
        // Run through all Primary Objectivies in mission data, then determine if all of them are complete.
        foreach (Objective pObjective in liveData.activeMission.primaryObjectives)
        {
            if (pObjective.isObjectiveFailed(liveData))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsMissionComplete()
    {
        // Run through all Primary Objectivies in mission data, then determine if all of them are complete.
        foreach (Objective pObjective in liveData.activeMission.primaryObjectives)
        {
            if (!pObjective.isObjectiveComplete(liveData))
            {
                return false;
            }
        }
        return true;
    }
}
