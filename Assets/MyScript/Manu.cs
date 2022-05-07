using LevelManagement;
using AudioManagement;
using UnityEngine;

public class Manu : MonoBehaviour
{
    [SerializeField]
    GameObject levels;
    public void play()
    {
        AudioManager.Instance.play(SoundType.ButtonClick);
        MySceneManager.nextLevel();
    }
    public void quit()
    {
        PlayerPrefs.DeleteAll();
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
