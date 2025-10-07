using UnityEngine;
using UnityEngine.UI;

public class ThrustSliderController : MonoBehaviour
{

    [SerializeField] LiveData liveData;
    Slider slider;

    void setThrottleUI()
    {
        slider.value = liveData.throttle;
    }

    public void onSliderChange()
    {
        liveData.throttle = slider.value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
        setThrottleUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != liveData.throttle)
        {
            setThrottleUI();
        }   
    }
}
