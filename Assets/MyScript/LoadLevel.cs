using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace LevelManagement
{
    public class LoadLevel : MonoBehaviour
    {
        public string level;
        Button button;
        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => loadLevel(level));
        }
        void loadLevel(string level)
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(level);
            switch (levelStatus)
            {
                case LevelStatus.locked:
                    Debug.Log("Level is locked");
                    break;
                case LevelStatus.unlocked:
                    Debug.Log("level is unlocked");
                    SceneManager.LoadScene(level);
                    break;
                case LevelStatus.complete:
                    Debug.Log("level is complete");
                    SceneManager.LoadScene(level);
                    break;
            }
        }
    }
}