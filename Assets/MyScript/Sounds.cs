using UnityEngine.Audio;
using UnityEngine;

namespace AudioManagement
{
    [System.Serializable]
    public class Sounds
    {
        public SoundType soundType;
        public AudioClip audio;
        [Range(0f,1f)]
        public float volume;
    }
    public enum SoundType
    {
        ButtonClick,
        GamePlay,
    }
}
