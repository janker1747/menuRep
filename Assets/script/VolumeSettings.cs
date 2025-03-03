using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] protected AudioMixerGroup _mixer; 
    protected string _mixerGroup; 

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_mixerGroup, Mathf.Log(volume) * 20); 
    }
}