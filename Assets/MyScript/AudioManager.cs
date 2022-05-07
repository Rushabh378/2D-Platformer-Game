using UnityEngine.Audio;
using UnityEngine;
using System;

namespace AudioManagement
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;
        public static AudioManager Instance { get { return instance; } }
        public Sounds[] sounds;
        public AudioSource BGAudio;
        public AudioSource AudioSFX;
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
        public void play(SoundType sound)
        {
            AudioClip audio = getSound(sound);
            if(audio != null)
            {
                AudioSFX.PlayOneShot(audio);
            }
        }

        private AudioClip getSound(SoundType sound)
        {
            Sounds audio = Array.Find(sounds, type => type.soundType == sound);
            if (audio != null)
                return audio.audio;
            else
                return null;
        }
    }
}
