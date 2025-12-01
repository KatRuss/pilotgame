using TMPro;
using UnityEngine;

public class LevelButtonController : MonoBehaviour
{

    [SerializeField] SharedInt levelToLoad;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI numberText;
    [SerializeField] TextMeshProUGUI meritsText;
    [SerializeField] MissionList missionList;
    public int missionNumber;

    private void Awake()
    {
        titleText.text = missionList.missions[missionNumber].menuName;
    }

    void Start()
    {
        titleText.text = $"{missionNumber + 1}. {missionList.missions[missionNumber].menuName}";
        //meritsText.text = "Dunno right now";
    }

    public void SetLevelToLoad()
    {
        levelToLoad.value = missionNumber;
    }

}
