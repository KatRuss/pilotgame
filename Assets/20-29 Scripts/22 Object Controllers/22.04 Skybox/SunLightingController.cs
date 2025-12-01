using UnityEngine;

public class SunLightingController : MonoBehaviour
{

    [SerializeField] LiveData liveData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float[] timesOfDay = { -12, -5, 20, 80};
        float time = timesOfDay[Random.Range(0, timesOfDay.Length)];

        if (liveData.activeMission is null)
        {
            transform.Rotate(new Vector3(time, 0, 0));
        }
        else
        {
            transform.Rotate(new Vector3((float)liveData.activeMission.timeOfDay, 0, 0));
        }
    }
}
