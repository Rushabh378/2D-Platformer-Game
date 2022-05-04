using UnityEngine;
namespace LevelManagement
{
    public enum LevelStatus
    {
        locked,
        unlocked,
        complete
    }
    public static class LevelsName
    {
        static string[] levelsName = { "Level1", "Level2", "Level3" };
        static int index;

        public static string getLevel(int index)
        {
            return levelsName[index - 1];
        }
    }
}