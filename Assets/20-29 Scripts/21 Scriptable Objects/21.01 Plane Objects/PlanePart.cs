using UnityEngine;

[CreateAssetMenu(fileName = "PlanePart", menuName = "PlanePart", order = 0)]
public class PlanePart : ScriptableObject
{
    [Header("Part Menu Data")]
    public string partName;
    [TextArea(2,2)] public string partDescription;
    
    [Header("Part Universal Data")]
    public float weight;
}