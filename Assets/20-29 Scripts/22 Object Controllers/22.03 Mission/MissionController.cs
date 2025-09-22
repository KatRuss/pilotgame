using Unity.Mathematics;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] LiveMissionData activeMission;
    [SerializeField] LivePlayerData livePlayerData;

    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnLevelPrefab();
        SpawnPlayer();
    }

    void SpawnLevelPrefab()
    {
        Instantiate(activeMission.getMissionObject());
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(playerObject,activeMission.getPlayerStart().position,Quaternion.identity);
        GameObject camera = Instantiate(cameraObject);
        camera.GetComponent<CameraController>().addPov(player.transform.Find("CameraPosition"),true);
    }
}
