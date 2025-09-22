using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Mission", order = 0)]
public class Mission : ScriptableObject
{
    public GameObject missionPrefab;

    public Transform getPlayerStartingTransform()
    {
        return missionPrefab.transform.Find("PlayerStart");
    }
}