using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textp;

    // Update is called once per frame
    void Update()
    {
        textp.text = $"FPS: {(int)(1.0f/Time.smoothDeltaTime)}";
    }
}
