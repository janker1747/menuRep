using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OnOffSound : MonoBehaviour
{
     private const string MixerGroup = "MasterVolume";

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private bool _isMuted;

    public void ToggleMixer()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _mixerGroup.audioMixer.SetFloat(MixerGroup, -80f);
        }
        else
        {
            _mixerGroup.audioMixer.SetFloat(MixerGroup, 0f);
        }
    }
}
