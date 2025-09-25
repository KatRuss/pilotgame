using UnityEngine;

[CreateAssetMenu(fileName = "ProgressionList", menuName = "Progression/ProgressionList", order = 0)]
public class ProgressionList : ScriptableObject {
    public ProgressionItem[] items;
}