using System;
using UnityEngine;

public class OptionScreenControlller : MonoBehaviour {
    [SerializeField] OptionList listToShow;
    [SerializeField] GameObject buttonOptionPrefab;
    [SerializeField] GameObject sliderOptionPrefab;

    void Start()
    {
        FillOptionsMenu();
    }

    void FillOptionsMenu()
    {
        foreach (var option in listToShow.options)
        {
            //Instantiate object based on type
            if (option is BoolOption boolOption)
            {
                var newBoolOption = Instantiate(buttonOptionPrefab);
                newBoolOption.GetComponent<OptionButtonController>().settingToMonitor = boolOption;
                newBoolOption.transform.SetParent(transform);
            }
            else if (option is SliderOption sliderOption)
            {
                //Create SliderOptionObject
                var newSlideOption = Instantiate(sliderOptionPrefab);
                newSlideOption.GetComponent<OptionSliderContoller>().settingToMonitor = sliderOption;
                newSlideOption.transform.SetParent(transform);
            }
            else
            {
                Debug.LogError("ERROR: option is not of implemented type");
            }
        }
    }
}