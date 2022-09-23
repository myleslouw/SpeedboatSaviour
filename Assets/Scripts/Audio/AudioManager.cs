using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Audio;

//https://www.youtube.com/watch?v=6OT43pvUyfY
//followed Brackeys tutorial on Audio in Unity


public class AudioManager : MonoBehaviour
{
    public SoundObj[] sounds;

    private void Awake()
    {
        foreach (SoundObj sound in sounds)
        {
            //links the sounds with the audio manager
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.soundLoop;

        }
    }

    public void Play(string soundName)
    {
        //starts a sound
        SoundObj sound = Array.Find(sounds, sound => sound.SoundName == soundName);
        sound.source.Play();
    }
    public void StopPlaying(string _soundName)
    {
        //stops a sound
        SoundObj sound = Array.Find(sounds, sound => sound.SoundName == _soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Stop();
    }
}
