using UnityEngine;

public class SunLightingController : MonoBehaviour
{

    [SerializeField] LiveData liveData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (liveData.activeMission is null)
        {
            transform.Rotate(new Vector3(60,0,0));
        }
        else
        {
            transform.Rotate(new Vector3((float)liveData.activeMission.timeOfDay,0,0));   
        }
    }
}
