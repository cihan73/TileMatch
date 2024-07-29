using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioData")]
public class AudioDataSO : ScriptableObject
{
    public AudioData[] audioDataArray;
}

[System.Serializable]
public struct AudioData
{
    public string id;
    public AudioClip clip;
}