using TMPro;
using UnityEngine;

public class FuelGageController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] LiveData livePlayerData;

    void Update()
    {
        text.text = $"{Mathf.RoundToInt(livePlayerData.fuel)}";
    }
}
