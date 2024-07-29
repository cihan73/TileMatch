using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioDataSO audioDataSO;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlaySound(string id, float volume = 1)
    {
        var clip = audioDataSO.audioDataArray.FirstOrDefault(a => a.id == id).clip;
        if (clip != null)
        {
            _audioSource.volume = volume;
            _audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError($"Audio clip with id {id} not found.");
        }
    }
}