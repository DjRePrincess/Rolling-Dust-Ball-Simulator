using UnityEngine;

// Purpose: If Game State is Win, then roll the WinSequence()
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
        // nextLevel()? and if its the last level, just go to first level 
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
