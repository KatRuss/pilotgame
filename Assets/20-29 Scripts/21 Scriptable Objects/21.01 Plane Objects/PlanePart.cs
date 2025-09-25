using UnityEngine;

[CreateAssetMenu(fileName = "PlanePart", menuName = "PlanePart", order = 0)]
public class PlanePart : ScriptableObject
{
    [Header("Part Data")]
    public string partName;
    public float weight;
}