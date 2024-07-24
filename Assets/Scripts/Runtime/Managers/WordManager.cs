
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] private TextAsset wordFile;
    [SerializeField] private Board board;
    private List<string> _prevWords = new();
    private string[] _wordArray;
    private string _currentWord;
    private bool _isValid;

    private void Awake()
    {
        var lines = wordFile.text.Split(new[] { '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries);

        _wordArray = lines.Select(line => line.Trim()).ToArray();
    }

    public void SetCurrentWord(string word)
    {
        _currentWord = word.ToLowerInvariant();
        _isValid = IsWordValid(word);
    }

    public bool IsCurrentWordValid()
    {
        return _isValid && !_prevWords.Contains(_currentWord);
    }

    private bool IsWordValid(string word)
    {
        return _wordArray.Contains(word);
    }
}
