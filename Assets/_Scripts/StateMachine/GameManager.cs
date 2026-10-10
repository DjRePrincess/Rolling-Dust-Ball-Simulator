using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;

    public static event Action<GameState> OnGameStateChanged;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // update the game, to the first state 
        UpdateGameState(GameState.Play);
    }

    public void UpdateGameState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Play:
                break;

            case GameState.Menu:
                break;

            case GameState.Win:
                break;

            case GameState.Lose:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        // has anybody subcrided to this function? if yes, invoke this function
        OnGameStateChanged?.Invoke(newState);

    }

    private void FreezePlayer()
    {
        player.SetActive(false);
    }
    // no opening scene yet

    private void HandleOpeningGame()
    {
        FreezePlayer();
    }
}
public enum GameState
{
    Play,
    Menu,
    Win,
    Lose,
}
