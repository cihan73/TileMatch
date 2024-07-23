using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using static TouchManager;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab;
    [SerializeField] LevelSelectionSO levelSelectionSo;

    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent;
    [SerializeField] SubmitManager submitManager;

    public TileCommandInvoker TileCommandInvoker => _tileCommandInvoker;

    public Tile[] Tiles { get; private set; }
    private TileCommandInvoker _tileCommandInvoker;

    private void Awake()
    {
        _tileCommandInvoker = new TileCommandInvoker();

        TouchEvents.OnElementTapped += TileTapped;

        PrepareTiles();
    }

    private void OnDestroy()
    {
        TouchEvents.OnElementTapped -= TileTapped;
    }

    private void PrepareTiles()
    {
        var tileCount = levelSelectionSo.levelData.tiles.Length;
        Tiles = new Tile[tileCount];

        for (int i = 0; i < tileCount; i++)
        {
            Tiles[i] = Instantiate(tilePrefab, tileParent);
            Tiles[i].Prepare(levelSelectionSo.levelData.tiles[i]);
        }

        GameEvents.OnTilesSpawned?.Invoke(Tiles);
    }

    private void TileTapped(ITouchable touchable)
    {
        var tappedTile = touchable.gameObject.GetComponent<Tile>();

        if (!CanTap(tappedTile)) return;
        if (!submitManager.HasEmptyBlock()) return;

        var emptyBlock = submitManager.GetFirstEmptyBlock();
        _tileCommandInvoker.AddCommand(tappedTile, emptyBlock);
    }

    private bool CanTap(Tile tile)
    {
        return tile.SubmitBlock == null
            && IsVisible(tile);
    }

    public bool IsVisible(Tile tile)
    {
        return Tiles.All(t => t.GetChildren() == null
                              || Array.IndexOf(t.GetChildren(), tile.GetID()) == -1);
    }
}