using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] LiveMissionData liveMissionData;
    [SerializeField] LivePlayerData livePlayerData;

    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;

    bool missionComplete = false;
    bool missionFailed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnLevelPrefab();
        SpawnPlayer();
    }

    void Update()
    {
        if (!missionFailed && !missionComplete)
        {
            MissionCheck();
        }
    }

    void SpawnLevelPrefab()
    {
        Instantiate(liveMissionData.activeMission.missionPrefab);
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(playerObject, liveMissionData.activeMission.getPlayerStartingTransform().position, Quaternion.identity);
        GameObject camera = Instantiate(cameraObject);
        camera.GetComponent<CameraController>().addPov(player.transform.Find("CameraPosition"), true);
    }

    void MissionCheck()
    {
        if (!isMissionFailed())
        {
            if (isMissionComplete())
            {
                Debug.Log("mission success");
                missionComplete = true;
            }
        }
        else
        {
            Debug.Log("mission failed");
            missionFailed = true;
        }
    }

    public bool isMissionFailed()
    {
        // Run through all Primary Objectivies in mission data, then determine if all of them are complete.
        foreach (Objective pObjective in liveMissionData.activeMission.primaryObjectives)
        {
            if (pObjective.isObjectiveFailed(liveMissionData, livePlayerData))
            {
                return true;
            }
        }
        return false;
    }

    public bool isMissionComplete()
    {
        // Run through all Primary Objectivies in mission data, then determine if all of them are complete.
        foreach (Objective pObjective in liveMissionData.activeMission.primaryObjectives)
        {
            if (!pObjective.isObjectiveComplete(liveMissionData, livePlayerData))
            {
                return false;
            }
        }
        return true;
    }
}
