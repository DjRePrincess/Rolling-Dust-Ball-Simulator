using UnityEngine;

// Purpose: Update Game State to Win if Player gets to the exit 
public class ExitTouched : MonoBehaviour
{
    private string playerTag = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        bool collidedWithPlayer = collision.collider.CompareTag(playerTag);
        if (collidedWithPlayer)
        {
            print("win state");
            UpdateGameStateToWin();
        }
    }

    private void UpdateGameStateToWin()
    {
        GameManager.Instance.UpdateGameState(GameState.Win);
    }
}
