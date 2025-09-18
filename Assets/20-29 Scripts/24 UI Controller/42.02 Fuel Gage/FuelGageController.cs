using TMPro;
using UnityEngine;

public class FuelGageController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] LivePlayerData livePlayerData;

    void Update()
    {
        text.text = $"{Mathf.RoundToInt(livePlayerData.fuel)}";
    }
}
