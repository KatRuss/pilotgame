using UnityEngine;

public class GameEndCheck : MonoBehaviour
{
    [SerializeField] GameObject conclusionScreen;
    [SerializeField] LiveGameData liveData;

    // Update is called once per frame
    void Update()
    {
        if (liveData.missionComplete || liveData.missionFailed)
        {
            conclusionScreen.SetActive(true);
        }
    }
}
