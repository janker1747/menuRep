using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private OnOffSound _onOffSound;
    [SerializeField] protected AudioMixerGroup _mixer;

    protected string _mixerGroup;
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
        if (isMuted)
        {
            _mixer.audioMixer.GetFloat(_mixerGroup, out _savedVolume);
            _mixer.audioMixer.SetFloat(_mixerGroup, -80f);
        }
        else 
        {
            _mixer.audioMixer.SetFloat(_mixerGroup, _savedVolume);
        }
    }

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_mixerGroup, Mathf.Log(volume) * 20);
    }

}