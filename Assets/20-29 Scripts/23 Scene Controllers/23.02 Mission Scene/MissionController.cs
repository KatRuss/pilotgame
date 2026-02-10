using UnityEngine;
using UnityEngine.SceneManagement;
public class MissionController : MonoBehaviour
{
    [SerializeField] LiveGameData liveData;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;

    Scene tempMissionScene;
    Scene playerScene;

    bool missionBegin = true;


    void Start()
    {
        //liveData.throttle = liveData.activeMission.startingThrottle;

        SetUpLevel();
    }

    void SetUpLevel()
    {
        tempMissionScene = SceneManager.CreateScene("S-Mission-Temp");
        GameObject level = Instantiate(liveData.activeMission.missionPrefab);
        GameObject camera = Instantiate(cameraObject);

        SceneManager.MoveGameObjectToScene(level, tempMissionScene);
        SceneManager.MoveGameObjectToScene(camera, tempMissionScene);

        if (missionBegin)
        {
            SpawnPlayer(camera);
            liveData.playerActive = true;
            liveData.throttle = liveData.activeMission.startingThrottle;
            liveData.fuel = liveData.activeMission.startingFuel;
        }
    }

    void SpawnPlayer(GameObject cam)
    {
        GameObject player = Instantiate(playerObject, liveData.activeMission.GetPlayerStartingTransform().position, Quaternion.identity);
        cam.GetComponent<CameraController>().AddPov(player.transform.Find("CameraPosition"), true);
        cam.transform.position = player.transform.position;
        player.transform.Rotate(new Vector3(0,liveData.activeMission.GetPlayerStartingTransform().eulerAngles.y,0));

        playerScene = SceneManager.CreateScene("S-Player-Temp");
        SceneManager.MoveGameObjectToScene(player,playerScene);
    }

    void OnDestroy()
    {
        SceneManager.UnloadSceneAsync(playerScene);
        SceneManager.UnloadSceneAsync(tempMissionScene);
    }

    void Update()
    {
        if (!liveData.missionFailed && !liveData.missionComplete && liveData.activeMission != null)
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
            if (IsMissionFailed())
            {
                Debug.Log("mission failed");
                liveData.missionFailed = true;
            }

            if (IsMissionComplete()){ liveData.missionComplete = true; }
        }

    }

    void SecondaryMissionCheck()
    {
        for (int i = 0; i < liveData.activeMission.secondaryObjectives.Length; i++)
        {
            if (liveData.activeMission.secondaryObjectives[i].IsObjectiveComplete(liveData))
            {
                liveData.activeMission.secondayObjectivesCompleted[i] = true;
            }
        }
    }

    public bool IsMissionFailed()
    {
        // Run through all Primary Objectivies in mission data, then determine if all of them are complete.
        foreach (Objective pObjective in liveData.activeMission.primaryObjectives)
        {
            if (pObjective.IsObjectiveFailed(liveData))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsMissionComplete()
    {
        // Run through all Primary Objectivies in mission data, then determine if all of them are complete.
        for (int i = 0; i < liveData.activeMission.primaryObjectives.Length; i++)
        {
            Objective pObjective = liveData.activeMission.primaryObjectives[i];
            if (!pObjective.IsObjectiveComplete(liveData))
            {
                return false;
            }
            else
            {
                liveData.activeMission.primaryObjectiveCompleted[i] = true;
            }
        }
        return true;
    }
}
