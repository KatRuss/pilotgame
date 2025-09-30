using UnityEngine;
using UnityEngine.UIElements;

public class LevelLoadOverride : MonoBehaviour
{

    [SerializeField] Mission missionToLoad;
    [SerializeField] LiveData liveData;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        liveData.activeMission = missionToLoad;
    }
}
