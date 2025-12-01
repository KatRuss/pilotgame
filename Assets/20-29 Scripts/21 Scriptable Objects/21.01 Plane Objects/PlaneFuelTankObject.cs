using UnityEngine;

[CreateAssetMenu(fileName = "New Fuel Tank", menuName = "Plane/Fuel Tank", order = 0)]
public class PlaneFuelTankObject : PlanePart
{
    [Tooltip("The max amount of fuel that can be put in the tank")]
    public float fuelMaximum;
    public float fuelWeightPerLitre;
}