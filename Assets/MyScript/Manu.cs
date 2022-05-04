using LevelManagement;
using UnityEngine;

public class Manu : MonoBehaviour
{
    [SerializeField]
    GameObject levels;
    public void play()
    {
        MySceneManager.nextLevel();
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("quited");
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void loadLevels()
    {
        levels.SetActive(true);
        enabled = false;
    }
    public void restart()
    {
        MySceneManager.reload();
    }
}
