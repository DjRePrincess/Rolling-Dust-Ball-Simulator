using UnityEngine;
using UnityEngine.SceneManagement;

// Purpose: If Game State is Lose, then roll the LoseSequence()
public class LoseManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        // script EnemyTouched will handle changing the gamestate to lose
        if (state == GameState.Lose)
        {
            LoseSequence();
        }
    }

    private void LoseSequence()
    {
        // LoseScreen.SetActive(true);
        player.SetActive(false); // disable player
        // we can a WaitXSeconds(x = 2) here
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
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
