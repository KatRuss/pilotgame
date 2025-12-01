using UnityEngine;

public class LevelLoadOverride : MonoBehaviour
{

    [SerializeField] Mission missionToLoad;
    [SerializeField] LiveGameData liveData;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        liveData.activeMission = missionToLoad;
    }
}
