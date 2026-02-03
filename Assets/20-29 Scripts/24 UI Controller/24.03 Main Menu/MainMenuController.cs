using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] LiveGameData liveData;
    [SerializeField] SharedInt levelToShow;
    [SerializeField] SharedInt levelToLoad;

    [Header("Menu Objects")]
    [SerializeField] GameObject mainMenu;

    [Header("Options Menu Objects")]
    [SerializeField] GameObject optionsMenu;

    [Header("Level Select Objects")]
    [SerializeField] GameObject levelCard;
    [SerializeField] GameObject levelSelectMenu;
    [SerializeField] GameObject levelListHolder;
    int levelCurrentlyShowing = -1;

    [Header("Level Info Objects")]
    [SerializeField] TextMeshProUGUI levelTitleText;
    [SerializeField] TextMeshProUGUI levelInfoText;
    [SerializeField] TextMeshProUGUI primaryObjectivesText;
    [SerializeField] TextMeshProUGUI secondaryObjectivesText;

    [Header("Mission List")]
    [SerializeField] MissionList missionList;

    private void Awake()
    {
        populateLevelList();
        mainMenu.SetActive(true);
    }

    void Update()
    {
        PopulateLevelInformation();
    }

    public void populateLevelList()
    {
        for (int i = 0; i < missionList.missions.Length; i++)
        {
            var card = Instantiate(levelCard, levelListHolder.transform);
            card.GetComponent<LevelButtonController>().missionNumber = i;
        }
    }

    public void PopulateLevelInformation()
    {
        if (levelToShow.value != -1 || levelToShow.value != levelCurrentlyShowing)
        {
            primaryObjectivesText.text = "";
            secondaryObjectivesText.text = "";

            Mission levelInfo = missionList.missions[levelToShow.value];
            levelTitleText.text = levelInfo.menuName;
            levelInfoText.text = levelInfo.menuDescription;

            // Primary Objectives 
            for (int i = 0; i < levelInfo.primaryObjectives.Length; i++)
            {
                Objective objective = levelInfo.primaryObjectives[i];
                primaryObjectivesText.text += $"\n {objective.GetObjectiveString()}";
            }

            // Secondary Objectives 
            for (int i = 0; i < levelInfo.secondaryObjectives.Length; i++)
            {
                Objective objective = levelInfo.secondaryObjectives[i];
                string objectiveComplete = levelInfo.secondayObjectivesCompleted[i] ? "Pass" : "Not Yet!";

                secondaryObjectivesText.text += $"\n {objective.GetObjectiveString()}: {objectiveComplete}";
            }

            levelCurrentlyShowing = levelToShow.value;
        }
    }

    public void ShowLevelMenu()
    {
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void PlayLevel()
    {
        levelToLoad.value = levelToShow.value;
    }
}