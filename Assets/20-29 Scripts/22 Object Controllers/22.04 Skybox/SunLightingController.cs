using UnityEngine;

public class SunLightingController : MonoBehaviour
{

    [SerializeField] LiveMissionData missionData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(new Vector3(((float)missionData.activeMission.timeOfDay),0,0));
    }
}
