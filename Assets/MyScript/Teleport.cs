using UnityEngine;
using LevelManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    string nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            LevelManager.Instance.loadNextLevel(nextLevel);
            
    }
}
