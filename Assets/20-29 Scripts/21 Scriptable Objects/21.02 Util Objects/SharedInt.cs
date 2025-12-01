using UnityEngine;

[CreateAssetMenu(fileName = "New SharedInt", menuName = "Util/SharedInt", order = 0)]
public class SharedInt : ScriptableObject
{
    //Scriptable object containing a single number value, with a starting value when needed. Used to link the same data value 
    //Between different game object so they are not dependent on eachother. e.g. timers, 

    [SerializeField] int startingInt = 0;
    public int value;

    private void OnEnable() { ResetValue(); }

    void ResetValue() { value = startingInt; } 

}