using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Purpose: If Game State is Lose, then roll the LoseSequence()
public class LoseManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource loseSoundSource;

    private void Start()
    {
        loseSoundSource = GetComponent<AudioSource>();
    }
    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        // script EnemyTouched will handle changing the gamestate to lose
        if (state == GameState.Lose)
        {
            StartCoroutine(LoseSequence());
        }
    }

    private IEnumerator LoseSequence()
    {
        // LoseScreen.SetActive(true);
        //DisablePlayer();
        PlayLoseSound();

        yield return new WaitForSeconds(1);
        
        ReloadLevel();
    }

    private void DisablePlayer()
    {
        player.SetActive(false);
    }

    private void PlayLoseSound()
    {
        if (loseSoundSource.isPlaying)
        {
            return;
        }
        loseSoundSource.Play();

        // do i need to stop it ?
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
