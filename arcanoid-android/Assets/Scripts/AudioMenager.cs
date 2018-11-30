using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioMenager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioMenager instance;

    void Awake() {

        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning(this.name+": Can't find sound with name= " + name);
            return;
        }
        s.source.Play();
    }



    public void PlayTheme(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.Log("No sound with name "+name);
            return;
        }

        if (!s.source.isPlaying) {
            StopAllPlaying();
            s.source.Play();
        }
    }



    private void StopAllPlaying() {

        foreach (Sound s in sounds) {
            if (s.source.isPlaying) {
                s.source.Stop();
            }
        }
    }

}
