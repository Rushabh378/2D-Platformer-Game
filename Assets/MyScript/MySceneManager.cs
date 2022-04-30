using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public float timer = 5f;
    float timeElapsed;
    public void reload()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
