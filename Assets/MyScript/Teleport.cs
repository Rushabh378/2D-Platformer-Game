using UnityEngine;
using LevelManagement;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.loadNextLevel(LevelsName.getLevel(2));
        }
    }
}
