using TMPro;
using UnityEngine;

public class AltitudeController : MonoBehaviour
{

    [SerializeField] LiveGameData liveGame;
    [SerializeField] TextMeshProUGUI altitudeText;
    bool shouldBeActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var objective in liveGame.activeMission.primaryObjectives)
        {
            if (objective is AltitudeObjective)
            {
                shouldBeActive = true;
            }
        }
        foreach (var objective in liveGame.activeMission.secondaryObjectives)
        {
            if (objective is AltitudeObjective)
            {
                shouldBeActive = true;
            }
        }
        if (!shouldBeActive)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        altitudeText.text = Mathf.Round(liveGame.altitude).ToString();
    }
}
