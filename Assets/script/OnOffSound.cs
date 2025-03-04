using System;
using UnityEngine;

public class OnOffSound : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener; 

    public event Action<bool> SoundStateChanged; 

    private bool _isMuted;

    public void ToggleSound()
    {
        _isMuted = !_isMuted; 

        if (_audioListener != null)
        {
            _audioListener.enabled = !_isMuted;
        }

        SoundStateChanged?.Invoke(_isMuted);
    }
}