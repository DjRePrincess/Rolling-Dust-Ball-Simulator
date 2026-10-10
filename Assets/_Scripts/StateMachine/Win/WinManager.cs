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
        NextLevel();
    }

    private void NextLevel()
    {
        // minus 1 because we are going to compare this to an index, which starts at 0
        int totalSceneCount = SceneManager.sceneCountInBuildSettings - 1;
        int currScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currScene + 1;

        // if nextScene will be out of range of the scene index list
        if (nextScene > totalSceneCount)
        {
            LoadFirstScene();
        }
        else
        {
            LoadNextScene(nextScene);
        }

    }

    private void LoadFirstScene()
    {
        int firstScene = 0;
        SceneManager.LoadScene(firstScene);
    }

    private void LoadNextScene(int scene)
    {
        SceneManager.LoadScene(scene);
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
