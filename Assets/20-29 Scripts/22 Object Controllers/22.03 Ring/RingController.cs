using UnityEngine;

public class RingController : MonoBehaviour
{
    [SerializeField] LiveData liveData;

    void OnTriggerEnter(Collider other)
    {
        // Signal to increase ring counter by 1
        liveData.ringsPassed += 1;
        Destroy(gameObject);
    }
}
