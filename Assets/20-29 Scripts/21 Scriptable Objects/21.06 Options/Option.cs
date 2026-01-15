using System;
using UnityEngine;

public abstract class Option : ScriptableObject {
    [Header("General Info")]
    public string optionTitle;
    public bool active;

    public virtual void setOption(int value) { throw new NotImplementedException(); }
}