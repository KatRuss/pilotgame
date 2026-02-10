using UnityEngine;

public class GoldStarController : MonoBehaviour
{

    [SerializeField] LiveGameData liveData;

    void Start()
    {
        GameObject star = GameObject.Find("GoldStar");
        // Only one gold star is allowed in a level at a time.
        if (star != gameObject)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        liveData.GoldStarCollected = true;
        Destroy(gameObject);
    }

}
