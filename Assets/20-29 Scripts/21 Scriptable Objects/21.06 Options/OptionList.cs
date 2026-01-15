using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionList", menuName = "Options/OptionList")]
public class OptionList : ScriptableObject
{
    [Header("List Settings")]
    public string optionsSubheading;
    public List<Option> options;
}
