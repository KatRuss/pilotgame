using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Mission/New Mission", order = 0)]
public class Mission : ScriptableObject
{
    public GameObject missionPrefab;

    public Objective[] primaryObjectives;
    public Objective[] secondaryObjectives;

    public Transform getPlayerStartingTransform()
    {
        return missionPrefab.transform.Find("PlayerStart");
    }
}