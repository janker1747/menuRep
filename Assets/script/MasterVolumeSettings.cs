using UnityEngine;
using UnityEngine.Audio;

public class MasterVolumeSettings : VolumeSettings
{
    private const string MixerGroup = "MasterVolume";

    private void Awake()
    {
        _mixerGroup = MixerGroup;
    }
}
