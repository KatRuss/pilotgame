using UnityEngine;

public class PauseController : MonoBehaviour
{

    [SerializeField] LiveGameData liveData;
    [SerializeField] SharedInt levelToLoad;
    [SerializeField] GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (liveData.gameIsPaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (!liveData.gameIsPaused)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void SetPause(bool pause)
    {
        liveData.gameIsPaused = pause;
    }

    public void ShowOptions()
    {
        Debug.Log("Show Options");
    }

    public void UnloadLevel()
    {
        levelToLoad.value = -1;
    }
}
