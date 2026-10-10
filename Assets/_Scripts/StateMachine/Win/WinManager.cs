using UnityEngine;
using UnityEngine.SceneManagement;

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
        NextLevel();
    }

    private void NextLevel()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currScene + 1;
        SceneManager.LoadScene(nextScene);
        // what to do when we run out of scenes?

        SceneManager.GetAllScenes();
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
