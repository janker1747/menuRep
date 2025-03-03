using UnityEngine;
using UnityEngine.Audio;

public class OnOffSound : MonoBehaviour
{
     private const string MixerGroup = "MasterVolume";

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private bool _isMuted;
    private float _savedVolume;

    public void ToggleMixer()
    {
        _isMuted = !_isMuted; 

        if (_isMuted)
        {
            _mixerGroup.audioMixer.GetFloat(MixerGroup, out _savedVolume);
            _mixerGroup.audioMixer.SetFloat(MixerGroup, -80f);
        }
        else
        {
            _mixerGroup.audioMixer.SetFloat(MixerGroup, _savedVolume);
        }
    }
}
