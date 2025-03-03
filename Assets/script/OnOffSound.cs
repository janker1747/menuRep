using System;
using UnityEngine;
using UnityEngine.Audio;

public class OnOffSound : MonoBehaviour
{
     private const string MixerGroup = "MasterVolume";

    [SerializeField] private AudioMixerGroup _mixerGroup;

    public event Action<bool> SoundStateChanged;

    private bool _isMuted;
    private float _savedVolume;

    public void ToggleSound()
    {
        if (_isMuted)
        {
            UnmuteSound();
        }
        else
        {
            MuteSound();
        }

        _isMuted = !_isMuted;
        SoundStateChanged?.Invoke(_isMuted);
    }

    private void MuteSound()
    {
        _mixerGroup.audioMixer.GetFloat(MixerGroup, out _savedVolume);
        _mixerGroup.audioMixer.SetFloat(MixerGroup, -80f);
    }

    private void UnmuteSound()
    {
        _mixerGroup.audioMixer.SetFloat(MixerGroup, _savedVolume);
    }
}
