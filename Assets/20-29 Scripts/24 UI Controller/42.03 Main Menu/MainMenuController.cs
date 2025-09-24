using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] SharedInt levelToLoad;
    [SerializeField] RectTransform leftPoint;
    [SerializeField] RectTransform rightPoint;

    [SerializeField] float menuSpeed;

    GameObject menuOnCenter;
    GameObject menuOnLeft;
    GameObject menuOnRight;



    void Start()
    {
        menuOnCenter = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        //menuOnCenter.transform.position = Vector3.Lerp(menuOnCenter.transform.position, new Vector3(0, 0, 0), menuSpeed * Time.deltaTime);
        //menuOnLeft.transform.position = Vector3.Lerp(menuOnLeft.transform.position, leftPoint.position, menuSpeed * Time.deltaTime);
        //menuOnRight.transform.position = Vector3.Lerp(menuOnRight.transform.position, rightPoint.position, menuSpeed * Time.deltaTime);
    }

    public void SetLevelToLoad(int levelID)
    {
        levelToLoad.value = levelID;
    }

    public void MoveToLeft()
    {
        GameObject g = menuOnCenter;
        menuOnCenter = menuOnLeft;
        menuOnLeft = g;
    }

    public void MoveToRight()
    {
        GameObject g = menuOnCenter;
        menuOnCenter = menuOnRight;
        menuOnRight = g;

    }

}
