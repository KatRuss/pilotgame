using TMPro;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] LiveGameData liveData;
    [SerializeField] SharedInt levelToLoad;
    
    [Header("Game End Gameobjects")]
    [SerializeField] TextMeshProUGUI conclusionText;
    [SerializeField] TextMeshProUGUI primaryObjectiveText;
    [SerializeField] TextMeshProUGUI secondaryObjectiveText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HandleGameEnd();
    }

    void HandleGameEnd()
    {
        Time.timeScale = 0.0f;

        if (liveData.missionComplete)
            conclusionText.text = "Level Complete";
        
        if (liveData.missionFailed)
            conclusionText.text = "Level Failed";
        
        // Primary Objectives 
        for (int i = 0; i < liveData.activeMission.primaryObjectives.Length; i++)
        {
            Objective objective = liveData.activeMission.primaryObjectives[i];
            string objectiveComplete = liveData.activeMission.primaryObjectiveCompleted[i] ? "Pass" : "Fail";

            primaryObjectiveText.text += $"\n {objective.GetObjectiveString()}: {objectiveComplete}";
        }

        // Secondary Objectives 
        for (int i = 0; i < liveData.activeMission.secondaryObjectives.Length; i++)
        {
            Objective objective = liveData.activeMission.secondaryObjectives[i];
            string objectiveComplete = liveData.activeMission.secondayObjectivesCompleted[i] ? "Pass" : "Not Yet!";

            secondaryObjectiveText.text += $"\n {objective.GetObjectiveString()}: {objectiveComplete}";
        }

        gameObject.SetActive(true);
    }


    public void UnloadLevel()
    {
        Time.timeScale = 1.0f;
        liveData.gameIsPaused = false;
        liveData.ResetAllValues();
        levelToLoad.value = -1;
    }
}
