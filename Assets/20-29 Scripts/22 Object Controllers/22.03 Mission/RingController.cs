using UnityEngine;

public class RingController : MonoBehaviour
{
    [SerializeField] LiveMissionData liveMissionData;

    void OnTriggerEnter(Collider other)
    {
        // Signal to increase ring counter by 1
        liveMissionData.ringsPassed += 1;
        Destroy(gameObject);
    }
}
