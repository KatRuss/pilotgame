using UnityEngine;

[CreateAssetMenu(fileName = "MissionSaveInfo", menuName = "Save/MissionSaveInfo", order = 0)]
public class MissionSaveInfo : ScriptableObject
{
    public bool isCompleted;
    public bool[] secondaryObjectivesComplete = {false,false,false};
}