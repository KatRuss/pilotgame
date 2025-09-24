using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Mission/Mission", order = 0)]
public class Mission : ScriptableObject
{
    public MissionLevelInfo levelInfo;
    public MissionSaveInfo saveInfo;
}