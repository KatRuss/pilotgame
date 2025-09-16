using UnityEditor.EditorTools;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fuel Tank", menuName = "Plane/Fuel Tank", order = 0)]
public class PlaneFuelTankObject : ScriptableObject
{
    public string tankName;

    [Tooltip("The minimum weight of the fueltank, even when if it is completely empty")]
    public float baseWeight;
    [Tooltip("The max amount of fuel that can be put in the tank")]
    public float fuelMaximum;
    public float fuelWeightPerLitre;
}