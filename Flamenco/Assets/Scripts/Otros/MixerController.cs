using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerGroup audioMixerGroup;
    public void SetLevel(float value)
    {
        mixer.SetFloat("VolumeValue", Mathf.Log10(value) * 20);
       
    }


    public void SetLevel2(float value)
    {

        audioMixerGroup.audioMixer.SetFloat("VolumeValue2", Mathf.Log10(value) * 20);
    }

}
