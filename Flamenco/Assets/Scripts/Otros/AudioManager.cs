using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.playOnAwake = s.playOnAwake;

			s.source.outputAudioMixerGroup = mixerGroup;
		}

        sounds[0].source.Play();
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " Nombre no encontrado!");
			return;
		}
		s.source.Play();
        
	}
    public void cambioboss()
    {
        sounds[0].source.Stop();
        sounds[1].source.Play();
    } 

}
