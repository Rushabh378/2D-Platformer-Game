using UnityEngine;

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
    }
}
