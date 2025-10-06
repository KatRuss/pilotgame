using System;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] GameObject levelCard;
    [SerializeField] GameObject levelListHolder;
    [SerializeField] GameObject levelSelectMenu;
    [SerializeField] MissionList missionList;
    [SerializeField] GameObject mainMenu;

    private void Awake()
    {
        populateLevelList();
        mainMenu.SetActive(true);
    }

    void Update()
    {
        //menuOnCenter.transform.position = Vector3.Lerp(menuOnCenter.transform.position, new Vector3(0, 0, 0), menuSpeed * Time.deltaTime);
        //menuOnLeft.transform.position = Vector3.Lerp(menuOnLeft.transform.position, leftPoint.position, menuSpeed * Time.deltaTime);
        //menuOnRight.transform.position = Vector3.Lerp(menuOnRight.transform.position, rightPoint.position, menuSpeed * Time.deltaTime);
    }

    public void populateLevelList()
    {
        for (int i = 0; i < missionList.missions.Length; i++)
        {
            var card = Instantiate(levelCard, levelListHolder.transform);
            card.GetComponent<LevelButtonController>().missionNumber = i;
        }
    }

    public void showLevelMenu()
    {
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
