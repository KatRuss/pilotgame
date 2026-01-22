using UnityEngine;

public class PauseButtonController : MonoBehaviour
{

    [SerializeField] LiveGameData liveGame;

    public void setPause()
    {
        liveGame.gameIsPaused = !liveGame.gameIsPaused;
    }
}
