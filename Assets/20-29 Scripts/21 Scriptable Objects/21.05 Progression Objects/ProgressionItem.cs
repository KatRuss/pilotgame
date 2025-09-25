using UnityEngine;

[CreateAssetMenu(fileName = "ProgressionItem", menuName = "Progression/ProgressionItem", order = 0)]
public class ProgressionItem : ScriptableObject
{
    public PlanePart planePart;
    public int meritsToUnlock;
    public bool unlocked;
}