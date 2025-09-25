using UnityEngine;

[CreateAssetMenu(fileName = "MissionList", menuName = "Mission/MissionList", order = 0)]
public class MissionList : ScriptableObject
{
    public Mission[] missions;
}