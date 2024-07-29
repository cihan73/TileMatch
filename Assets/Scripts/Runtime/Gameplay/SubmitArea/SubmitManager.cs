using System;
using System.Linq;
using UnityEngine;

public class SubmitManager : MonoBehaviour
{
    [SerializeField] SubmitBlock[] submitBlocks;
    [SerializeField] private WordManager wordManager;
    public SubmitBlock[] SubmitBlocks => submitBlocks;

    private void Awake()
    {
        GameEvents.OnTileAttached += OnWordAttachedCallback;
        GameEvents.OnTileRemoved += OnWordRemovedCallback;
        GameEvents.OnWordSubmitted += OnWordSubmittedCallback;
    }

    private void OnDestroy()
    {
        GameEvents.OnTileAttached -= OnWordAttachedCallback;
        GameEvents.OnTileRemoved -= OnWordRemovedCallback;
        GameEvents.OnWordSubmitted -= OnWordSubmittedCallback;
    }

    public bool HasEmptyBlock()
    {
        return submitBlocks.Count(sb => sb.IsEmpty) > 0;
    }

    public SubmitBlock GetFirstEmptyBlock()
    {
        return submitBlocks.FirstOrDefault(sb => sb.IsEmpty);
    }

    private void OnWordAttachedCallback(SubmitBlock submitBlock, string word)
    {
        var nonEmptyBlocks = submitBlocks.Where(sb => !sb.IsEmpty);
        var combinedWord = string.Join("", nonEmptyBlocks.Select(sb => sb.Character));
        wordManager.SetCurrentWord(combinedWord);
    }

    private void OnWordRemovedCallback(SubmitBlock submitBlock)
    {
        var nonEmptyBlocks = submitBlocks.Where(sb => !sb.IsEmpty);
        var combinedWord = string.Join("", nonEmptyBlocks.Select(sb => sb.Character));
        wordManager.SetCurrentWord(combinedWord);
    }

    private void OnWordSubmittedCallback()
    {
        foreach (var block in submitBlocks)
        {
            if (!block.IsEmpty)
            {
                block.Tile.Clear();
            }
        }
    }
}