using UnityEngine;

[CreateAssetMenu(fileName = "New Plane Body", menuName = "Plane/Plane Body", order = 0)]
public class PlaneBodyObject : PlanePart
{
    public string modelMenuName;
    public float responsiveness;
    public float lift;
    public float minimumStallThrust;
    public float stallThrustBurnRate;
    
}