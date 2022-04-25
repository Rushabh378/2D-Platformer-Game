using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            resumeGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.gameObject.GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.enabled = false;
            Debug.Log("Level Finished");
            pauseGame();
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0;
    }
    void resumeGame()
    {
        Time.timeScale = 1;
    }
}
