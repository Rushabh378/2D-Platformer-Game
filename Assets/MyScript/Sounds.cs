using UnityEngine.Audio;
using UnityEngine;

namespace AudioManagement
{
    [System.Serializable]
    public class Sounds
    {
        public string name;
        public AudioClip audio;
        [Range(0f,1f)]
        public float volume;
    }
}
