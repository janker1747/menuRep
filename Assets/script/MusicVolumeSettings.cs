using UnityEngine;
using UnityEngine.Audio;

public class MusicVolumeSettings : VolumeSettings
{
    private const string MixerGroup = "MusicVolume";

    private void Awake()
    {
        _mixerGroup = MixerGroup;
    }
}
