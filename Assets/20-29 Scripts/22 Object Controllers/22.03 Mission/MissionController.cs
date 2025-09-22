using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] LiveMissionData liveMissionData;
    [SerializeField] LivePlayerData livePlayerData;

    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnLevelPrefab();
        SpawnPlayer();
    }

    void Update()
    {
        if (isMissionComplete())
        {
            Debug.Log("mission complete!");
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
