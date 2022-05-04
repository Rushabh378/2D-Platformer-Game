using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance; } }
        string firstLevel = "Level1";
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            if(GetLevelStatus(firstLevel) == LevelStatus.locked)
            {
                setLevelStatus(firstLevel, LevelStatus.unlocked);
            }
        }
        public void setLevelStatus(string level, LevelStatus status)
        {
            PlayerPrefs.SetInt(level, (int)status);
        }
        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }
        public void loadNextLevel(string nextLevel)
        {
            
            //setting current scene status as complete.
            string currentLevel = SceneManager.GetActiveScene().name;
            Debug.Log("current scene name: " + currentLevel);
            setLevelStatus(currentLevel, LevelStatus.complete);

            //defining and loading next level
            setLevelStatus(nextLevel, LevelStatus.unlocked);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
