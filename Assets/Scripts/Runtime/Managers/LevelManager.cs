using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextAsset[] levelFiles;
    LevelData[] _levelData;

    void Awake()
    {
        ReadLevels();
    }

    void ReadLevels()
    {
        _levelData = new LevelData[levelFiles.Length];

        for (int i = 0; i < levelFiles.Length; i++)
        {
            _levelData[i] = JsonUtility.FromJson<LevelData>(levelFiles[i].text);
        }
    }
}