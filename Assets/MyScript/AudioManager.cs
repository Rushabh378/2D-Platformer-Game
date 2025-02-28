﻿using UnityEngine.Audio;
using UnityEngine;
using System;

namespace AudioManagement
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;
        public static AudioManager Instance { get { return instance; } }
        public AudioSource BGAudio;
        public AudioSource AudioSFX;
        public Sounds[] sounds;
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
            playMusic(SoundType.GamePlay);
        }
        public void play(SoundType sound)
        {
            AudioClip audio = getSound(sound);
            if (audio != null)
            {
                AudioSFX.PlayOneShot(audio);
            }
            else
                Debug.Log("audio clip is null");
        }
        public void playMusic(SoundType sound)
        {
            AudioClip audio = getSound(sound);

            if (audio != null)
            {
                BGAudio.clip = audio;
                BGAudio.loop = true;
                BGAudio.Play();
            }
            else
                Debug.Log("audio clip is null");
        }

        private AudioClip getSound(SoundType sound)
        {
            Sounds audio = Array.Find(sounds, type => type.soundType == sound);
            if (audio != null)
                return audio.audio;
            else
                return null;
        }

        //elen walking sound
        public void ellenWalking()
        {
            play(SoundType.EllenWalk);
        }
    }
}
