using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] LiveGameData liveGame;
    [SerializeField] TextMeshProUGUI timerText;
    bool shouldBeActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var objective in liveGame.activeMission.primaryObjectives)
        {
            if (objective is TimerObjective)
            {
                shouldBeActive = true;
            }
        }
        foreach (var objective in liveGame.activeMission.secondaryObjectives)
        {
            if (objective is TimerObjective)
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
        timerText.text = Mathf.Round(liveGame.timer).ToString();
    }
}
