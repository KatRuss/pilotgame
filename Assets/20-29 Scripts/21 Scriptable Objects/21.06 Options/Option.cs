using System;
using UnityEngine;

public abstract class Option : ScriptableObject {
    [Header("General Info")]
    public string optionTitle;

    public virtual void SetOption(int value) { throw new NotImplementedException(); }
}