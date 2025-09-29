using System.Collections.Generic;
using UnityEngine;
public class MissionController : MonoBehaviour
{
    [SerializeField] LiveData liveData;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn Player and level items
        List<int> instanceIDs = new List<int>();
        instanceIDs.Add(SpawnLevelPrefab());
        instanceIDs.AddRange(SpawnPlayer());

        //TODO: Move game objects to their own temp scene.

        liveData.throttle = liveData.activeMission.startingThrottle;
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


    int SpawnLevelPrefab()
    {
        GameObject level = Instantiate(liveData.activeMission.missionPrefab);
        return level.GetInstanceID();
    }

    List<int> SpawnPlayer()
    {
        GameObject player = Instantiate(playerObject, liveData.activeMission.getPlayerStartingTransform().position, Quaternion.identity);
        GameObject camera = Instantiate(cameraObject);
        camera.GetComponent<CameraController>().addPov(player.transform.Find("CameraPosition"), true);
        return new List<int> {player.GetInstanceID(), camera.GetInstanceID()};
    }

    void PrimaryMissionCheck()
    {
        for (int i = 0; i < liveData.activeMission.primaryObjectives.Length; i++)
        {
            if (!isMissionFailed())
            {
                if (isMissionComplete())
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

    public bool isMissionFailed()
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

    public bool isMissionComplete()
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
