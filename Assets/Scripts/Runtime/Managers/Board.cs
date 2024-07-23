using System;
using System.Linq;
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

    public Tile[] Tiles { get; private set; }

    void Awake()
    {
        TouchEvents.OnElementTapped += TileTapped;

        PrepareTiles();
    }

    void OnDestroy()
    {
        TouchEvents.OnElementTapped -= TileTapped;
    }

    void PrepareTiles()
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

    void TileTapped(ITouchable touchable)
    {
        var tappedTile = touchable.gameObject.GetComponent<Tile>();

        if (!CanTap(tappedTile)) return;
        if (!submitManager.HasEmptyBlock()) return;

        var emptyBlock = submitManager.GetFirstEmptyBlock();
    }

    bool CanTap(Tile tile)
    {
        return tile.SubmitBlock == null
            && IsVisible(tile);
    }

    bool IsVisible(Tile tile)
    {
        return Tiles.All(t => t.GetChildren() == null
                              || Array.IndexOf(t.GetChildren(), tile.GetID()) == -1);
    }
}