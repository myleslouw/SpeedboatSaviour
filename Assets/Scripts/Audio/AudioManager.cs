using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Audio;

//https://www.youtube.com/watch?v=6OT43pvUyfY
//followed Brackeys tutorial on Audio in Unity


public class AudioManager : MonoBehaviour
{
    //list of sound scriptable objects
    public List<SoundObj> sounds;

    private void Awake()
    {
        foreach (SoundObj sound in sounds)
        {
            //links the sounds in the list with the necessary audiosources

            if (!sound.ExistingSource)
            {
                //means it doesnt have a source given to it and will use the Game manager as the source
                sound.source = gameObject.GetComponent<AudioSource>();
            }

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.soundLoop;
            sound.source.spatialBlend = sound.spatialBlend;

        }
    }

    public void AddSoundToList(SoundObj newSound)
    {
        sounds.Add(newSound);
        print("Sound Added");
    }

    public void Play(string soundName)
    {
        //starts a sound
        SoundObj sound = sounds.Find(sound => sound.SoundName == soundName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        sound.source.Play();
    }
    public void StopPlaying(string _soundName)
    {
        //stops a sound
        SoundObj sound = sounds.Find(sound => sound.SoundName == _soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Stop();
    }
}
