using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private OnOffSound _onOffSound;
    [SerializeField] protected AudioMixerGroup _mixer;
    [SerializeField] private string _mixerGroup;

    private float _savedVolume;

    private void Awake()
    {
        _onOffSound = GetComponent<OnOffSound>();
    }

    private void OnEnable()
    {
        _onOffSound.SoundStateChanged += HandleSoundStateChanged;
    }

    private void OnDisable()
    {
        _onOffSound.SoundStateChanged -= HandleSoundStateChanged;
    }

    private void HandleSoundStateChanged(bool isMuted)
    {
        float minVolume = -80f;

        if (isMuted)
        {
            _mixer.audioMixer.GetFloat(_mixerGroup, out _savedVolume);
            _mixer.audioMixer.SetFloat(_mixerGroup, minVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_mixerGroup, _savedVolume);
        }
    }

    public void ChangeVolume(float volume)
    {
        float volumeMultiplier = 20f;

        _mixer.audioMixer.SetFloat(_mixerGroup, Mathf.Log10(volume) * volumeMultiplier);
    }

}