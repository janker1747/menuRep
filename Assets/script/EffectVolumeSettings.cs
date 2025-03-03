using UnityEngine;
using UnityEngine.Audio;

public class EffectVolumeSettings : VolumeSettings
{
    private const string MixerGroup = "EffectVolume";

    private void Awake()
    {
        _mixerGroup = MixerGroup;
    }
}
