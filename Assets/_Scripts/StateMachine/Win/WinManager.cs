using UnityEngine;

public class WinManager : MonoBehaviour
{

    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        if (state == GameState.Win)
        {
            WinSequence();
        }
    }

    private void WinSequence()
    {
        print("player wins");
    }

    // ------------------- default 

    private void Awake()
    {
        // subcribe to game state changed event 
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        // unsubcribe to event when this class gets destroyed 
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
}
