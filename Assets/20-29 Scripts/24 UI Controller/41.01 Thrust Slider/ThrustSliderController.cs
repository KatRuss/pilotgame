using UnityEngine;
using UnityEngine.UI;

public class ThrustSliderController : MonoBehaviour
{

    [SerializeField] LivePlayerData livePlayerData;
    Slider slider;

    void setThrottleUI()
    {
        slider.value = livePlayerData.throttle;
    }

    public void onSliderChange()
    {
        livePlayerData.throttle = slider.value;
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
        if (slider.value != livePlayerData.throttle)
        {
            setThrottleUI();
        }   
    }
}
