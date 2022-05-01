using UnityEngine;

public class Manu : MonoBehaviour
{
    MySceneManager sceneManager = new MySceneManager();
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
}
