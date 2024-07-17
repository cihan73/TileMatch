using UnityEngine;
using static TouchManager;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab;
    [SerializeField] LevelSelectionSO levelSelectionSo;

    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent;

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
    }

    void TileTapped(ITouchable touchable)
    {
        var tappedTile = touchable.gameObject.GetComponent<Tile>();
    }
}