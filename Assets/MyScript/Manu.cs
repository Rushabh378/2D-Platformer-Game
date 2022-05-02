using UnityEngine;

public class Manu : MonoBehaviour
{
    MySceneManager sceneManager = new MySceneManager();
    [SerializeField]
    GameObject levels;
    public void play()
    {
        sceneManager.nextLevel();
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
        sceneManager.reload();
    }
}
