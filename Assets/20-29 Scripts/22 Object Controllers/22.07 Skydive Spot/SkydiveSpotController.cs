using UnityEngine;

public class SkydiveSpotController : MonoBehaviour
{
    [SerializeField] LiveGameData liveData;
    [SerializeField] int requiredHeight;


    void OnTriggerEnter(Collider other)
    {
        if (liveData.distanceToGround >= requiredHeight)
        {
            liveData.skydiversDropped += 1;
            Destroy(gameObject);
        }
        else
        {
            liveData.headerToShow = "Not high enough!";
            liveData.messageToShow = $"You need to be {requiredHeight} above the ground!!";
        }
    }


}
