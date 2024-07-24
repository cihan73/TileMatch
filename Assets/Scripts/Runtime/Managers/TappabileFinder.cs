using System;
using UnityEngine;
[DefaultExecutionOrder(-900)]
public class TappabileFinder : MonoBehaviour
{
    [SerializeField] private Board board;

    private void Awake()
    {
        GameEvents.OnSearchVisibleTiles += Search;
    }

    private void OnDestroy()
    {
        GameEvents.OnSearchVisibleTiles -= Search;
    }

    private void Search()
    {
        foreach (var tile in board.Tiles)
        {
            tile.UpdateVisual(board.IsVisible(tile));
        }
    }
}