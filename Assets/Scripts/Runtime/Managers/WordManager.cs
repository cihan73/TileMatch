using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
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

    private async void CheckIfBoardHasValidWord()
    {
        var tiles = board.GetActiveTiles();

        if (tiles.Count <= 0)
        {
            //todo: complete level
            return;
        }

        var characters = tiles.Select(tile => tile.GetCharacter()).ToList();
        var checkList = _wordArray.Except(_prevWords);
        var validWordFound = await UniTask.RunOnThreadPool(() =>
                FindValidWord(checkList, characters));

        if (!validWordFound)
        {
            //todo: complete
        }
    }

    private bool FindValidWord(IEnumerable<string> wordList,
        IReadOnlyCollection<string> characters)
    {
        return wordList.Any(word => CanFormWord(word, characters));
    }

    private bool CanFormWord(string word, IEnumerable<string> characters)
    {
        var availableCharacter = new List<string>(characters);

        foreach (var charString in word.Select(ch => ch.ToString()))
        {
            if (availableCharacter.Contains(charString))
            {
                availableCharacter.Remove(charString);
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public void Submit()
    {
        _prevWords.Add(_currentWord);
        _currentWord = "";
        //todo: invoke action
        CheckIfBoardHasValidWord();
    }
}