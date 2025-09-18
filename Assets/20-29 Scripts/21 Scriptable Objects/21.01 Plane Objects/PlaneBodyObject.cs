using UnityEngine;

[CreateAssetMenu(fileName = "New Plane Body", menuName = "Plane/Plane Body", order = 0)]
public class PlaneBodyObject : ScriptableObject
{
    public string modelMenuName;
    public float weight;
    public float responsiveness;
    public float lift;
    public float stallThrust;
    public float stallThrustBurnRate;
    
}