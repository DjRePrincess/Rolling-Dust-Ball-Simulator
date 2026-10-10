using UnityEngine;

public class EnemyTouched : MonoBehaviour
{
    private string playerTag = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        bool collidedWithPlayer = collision.collider.CompareTag(playerTag);
        if (collidedWithPlayer)
        {
            // Debug.Log("collided with player");
            UpdateGameStateToLose();
        }
    }

    private void UpdateGameStateToLose()
    {
        GameManager.Instance.UpdateGameState(GameState.Lose);
    }
}
