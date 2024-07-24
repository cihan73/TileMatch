
using System;
using System.Linq;
using UnityEngine;

public class SubmitManager : MonoBehaviour
{
    [SerializeField] SubmitBlock[] submitBlocks;
    public SubmitBlock[] SubmitBlocks => submitBlocks;

    private void Awake()
    {
        GameEvents.OnTileAttached += OnWordAttachedCallback;
        GameEvents.OnTileRemoved += OnWordRemovedCallback;
    }

    private void OnDestroy()
    {
        GameEvents.OnTileAttached -= OnWordAttachedCallback;
        GameEvents.OnTileRemoved -= OnWordRemovedCallback;
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
        //todo: word manager set current word
    }

    private void OnWordRemovedCallback(SubmitBlock submitBlock)
    {
        var nonEmptyBlocks = submitBlocks.Where(sb => !sb.IsEmpty);
        var combinedWord = string.Join("", nonEmptyBlocks.Select(sb => sb.Character));
        //todo: word manager set current word
    }

    private void OnWordSubmittedCallback()
    {
        foreach (var block in submitBlocks)
        {
            if (!block.IsEmpty)
            {
                //todo: clear
            }
        }
    }
}
